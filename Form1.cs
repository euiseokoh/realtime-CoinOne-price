using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net.Http;

namespace Coin_robo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //private String[] coin_name_kor = { "비트코인", "이더리움", "라이트코인", "이더리움 클래식", "리플", "비트코인 캐시", "퀀텀", "비트코인 골드", "아이오타" };
        //private String[] coin_name_eng = { "BTC", "ETH", "LTC", "ETC", "XRP", "BCH", "QTUM", "BTG", "IOTA" };


        private String[] coin_name_kor = { "비트코인", "이더리움", "라이트코인", "이더리움 클래식", "리플", "비트코인 캐시", "퀀텀", "비트코인 골드", "아이오타", "오미세고", "이오스", "스트리머", "질리카", "카이버 네트워크", "제로엑스" };
        private String[] coin_name_eng = { "BTC", "ETH", "LTC", "ETC", "XRP", "BCH", "QTUM", "BTG", "IOTA", "OMG", "EOS", "DATA", "ZIL", "KNC", "ZRX" };

        string sRespBodyData = String.Empty;
        JObject JObj = null;
        Thread currentThread = null;
        Thread timerThread = null;

        public JObject getCoinOneTicker()
        {

            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.coinone.co.kr/ticker?currency=all&format=json");

                var Response = (HttpWebResponse)Request.GetResponse();

                sRespBodyData = new StreamReader(Response.GetResponseStream()).ReadToEnd();

                //Console.WriteLine(sRespBodyData);
                return (JObject.Parse(sRespBodyData));
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.ToString());
                return null;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
           
            add_log("프로그램 로딩 완료");

            add_log("현재가를 조회합니다.");
            Thread get_currency = new Thread(this.get_currency);
            get_currency.Start();
        }


        private void get_currency()
        {

            add_log("CoinOne Public API URI('/public/ticker') Request...");
            JObj = getCoinOneTicker();

            if (JObj == null)
            {
                add_log("Error occurred!");
                add_log("HTTP Response JSON Data: "+ sRespBodyData.ToString());
            }
            else
            {

                if (JObj["errorCode"].ToString().Equals("0"))
                {
                    DataGridView1.Rows.Clear();
                    int index = 0;
                    foreach (String coinname in coin_name_eng)
                    {
                        //Console.WriteLine(coin.Name);
                        //Console.WriteLine(JObj[coinname.ToString());
                        String coinnamedown = coinname.ToLower();

                        double currentRate = Math.Round((Convert.ToDouble(JObj[coinnamedown]["last"]) / Convert.ToDouble(JObj[coinnamedown]["yesterday_last"])) - 1, 4) * 100;
                        double averagePrice = Math.Round(((Convert.ToDouble(JObj[coinnamedown]["last"]) + Convert.ToDouble(JObj[coinnamedown]["low"]) + Convert.ToDouble(JObj[coinnamedown]["high"])) / 3), 0);

                        DataGridView1.Rows.Add(coinname, coin_name_kor[index],
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["last"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int((Convert.ToDouble(JObj[coinnamedown]["last"]) - Convert.ToDouble(JObj[coinnamedown]["yesterday_last"])).ToString()),
                            currentRate.ToString() + "%",
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["low"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["high"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int(averagePrice.ToString()),
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["volume"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_volume"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_high"]), 0).ToString()),
                            StrToNumFormat_Thousands_Int((averagePrice * Convert.ToDouble(JObj[coinnamedown]["volume"])).ToString())
                            );


                        Color colorcurrent = Color.Blue;
                        Color colormean = Color.Blue;
                        if (Convert.ToDouble(JObj[coinnamedown]["last"]) > Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]))
                        {
                            colorcurrent = Color.Red;
                        }
                        if (averagePrice > Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]))
                        {
                            colormean = Color.Red;
                        }



                        DataGridView1.Rows[index].Cells[3].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[4].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[5].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[8].Style.ForeColor = colormean;

                        index++;
                    }

                }
                else
                {
                    add_log("Error : " + JObj["errorCode"]);
                }
            }


        }

        private void add_log(String msg)
        {

            lbLog.Items.Add("[" + DateTime.Now.ToString() + "]" + msg);
            lbLog.TopIndex = lbLog.Items.Count - 1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_log("실시간 감시를 시작합니다.");
            if (currentThread != null)
            {
                currentThread.Abort();
                currentThread = null;
            }
            currentThread = new Thread(this.realtimeThread);
            currentThread.Start();


        }

        private void realtimeThread()
        {
            while (true)
            {

                try
                {
                    get_realtimecurrency();

                    Thread.Sleep((int)(1000 * 1)); // 1분에 60번 요청 제한
                }
                catch (Exception ex)
                {
                    add_log(ex.Message.ToString());
                }
            }
        }

        private void get_realtimecurrency()
        {

            JObj = getCoinOneTicker();
            if (JObj == null)
            {
                add_log("Error occurred!");
                add_log("HTTP Response JSON Data: " + sRespBodyData.ToString());
            }
            else
            {
                //Console.WriteLine(JObj.ToString());

                if (JObj["errorCode"].ToString().Equals("0"))
                {

                    int index = 0;
                    foreach (String coinname in coin_name_eng)
                    {

                        String coinnamedown = coinname.ToLower();


                        double currentRate = Math.Round((Convert.ToDouble(JObj[coinnamedown]["last"]) / Convert.ToDouble(JObj[coinnamedown]["yesterday_last"])) - 1, 4) * 100;
                        double averagePrice = Math.Round(((Convert.ToDouble(JObj[coinnamedown]["last"]) + Convert.ToDouble(JObj[coinnamedown]["low"]) + Convert.ToDouble(JObj[coinnamedown]["high"])) / 3), 0);


                        DataGridView1.Rows[index].Cells[2].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[3].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["last"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[4].Value = StrToNumFormat_Thousands_Int((Convert.ToDouble(JObj[coinnamedown]["last"]) - Convert.ToDouble(JObj[coinnamedown]["yesterday_last"])).ToString());
                        DataGridView1.Rows[index].Cells[5].Value = currentRate.ToString() + "%";
                        DataGridView1.Rows[index].Cells[6].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["low"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[7].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["high"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[8].Value = StrToNumFormat_Thousands_Int(averagePrice.ToString());
                        DataGridView1.Rows[index].Cells[9].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["volume"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[10].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_volume"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[11].Value = StrToNumFormat_Thousands_Int(Math.Round(Convert.ToDouble(JObj[coinnamedown]["yesterday_high"]), 0).ToString());
                        DataGridView1.Rows[index].Cells[12].Value = StrToNumFormat_Thousands_Int((averagePrice * Convert.ToDouble(JObj[coinnamedown]["volume"])).ToString());
                            

                        Color colorcurrent = Color.Blue;
                        Color colormean = Color.Blue;
                        if (Convert.ToDouble(JObj[coinnamedown]["last"]) > Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]))
                        {
                            colorcurrent = Color.Red;
                        }
                        if (averagePrice > Convert.ToDouble(JObj[coinnamedown]["yesterday_last"]))
                        {
                            colormean = Color.Red;
                        }



                        DataGridView1.Rows[index].Cells[3].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[4].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[5].Style.ForeColor = colorcurrent;
                        DataGridView1.Rows[index].Cells[8].Style.ForeColor = colormean;

                        index++;

                    }

                }
                else
                {
                    add_log("Error : " + JObj["errorCode"]);
                }
            }


        }


        public string StrToNumFormat_Thousands_Int(string str)
        {
            return Convert.ToDouble(str).ToString("#,##0");
        }
        public string StrToNumFormat_Thousands_Double2(string str)
        {
            return Convert.ToDouble(str).ToString("#,##0.00");
        }


        public static List<String[]> Sort_Keyvalue(string[] key, double[] value)
        {

            List<String[]> result = new List<string[]>();


            for(int i = 0; i < key.Length; i++)
            {

                for (int j = i + 1; j < key.Length; j++)
                {
                    if(value[i] < value[j])
                    {
                        string res_key = key[i];
                        double res_value = value[i];

                        value[i] = value[j];
                        key[i] = key[j];

                        value[j] = res_value;
                        key[j] = res_key;
                    }
                }

            }
            
            for (int i = 0; i < key.Length; i++)
            {

                String[] result_res = {key[i], value[i].ToString()};
                result.Add(result_res);
            }

            return result;

        }



        public String inttostring(int num)
        {
            String result = "";
            if(num < 10)
            {
                result = "000" + num.ToString();
            }
            else if(num < 100)
            {
                result = "00" + num.ToString();
            }
            else if (num < 1000)
            {
                result = "0" + num.ToString();
            }
            else
            {
                result = "" + num.ToString();
            }


            return result;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentThread != null)
            {
                currentThread.Abort();
                currentThread = null;
            }
            if (timerThread != null)
            {
                timerThread.Abort();
                timerThread = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_log("현재가를 조회합니다.");
            Thread get_currency = new Thread(this.get_currency);
            get_currency.Start();
        }
    }

    public class Korean
    {
        public class Josa
        {
            class JosaPair
            {
                public JosaPair(string josa1, string josa2)
                {
                    this.josa1 = josa1;
                    this.josa2 = josa2;
                }

                public string josa1
                { get; private set; }

                public string josa2
                { get; private set; }
            }

            public string Replace(string src)
            {
                var strBuilder = new StringBuilder(src.Length);
                var josaMatches = _josaRegex.Matches(src);
                var lastHeadIndex = 0;
                foreach (Match josaMatch in josaMatches)
                {
                    var josaPair = _josaPatternPaird[josaMatch.Value];

                    strBuilder.Append(src, lastHeadIndex, josaMatch.Index - lastHeadIndex);
                    if (josaMatch.Index > 0)
                    {
                        var prevChar = src[josaMatch.Index - 1];
                        if ((HasJong(prevChar) && josaMatch.Value != "(으)로") ||
                            (HasJongExceptRieul(prevChar) && josaMatch.Value == "(으)로"))
                        {
                            strBuilder.Append(josaPair.josa1);
                        }
                        else
                        {
                            strBuilder.Append(josaPair.josa2);
                        }
                    }
                    else
                    {
                        strBuilder.Append(josaPair.josa1);
                    }

                    lastHeadIndex = josaMatch.Index + josaMatch.Length;
                }
                strBuilder.Append(src, lastHeadIndex, src.Length - lastHeadIndex);
                return strBuilder.ToString();
            }

            static bool HasJong(char inChar)
            {
                if (inChar >= 0xAC00 && inChar <= 0xD7A3) // 가 ~ 힣
                {
                    int localCode = inChar - 0xAC00; // 가~ 이후 로컬 코드 
                    int jongCode = localCode % 28;
                    if (jongCode > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            static bool HasJongExceptRieul(char inChar)
            {
                if (inChar >= 0xAC00 && inChar <= 0xD7A3)
                {
                    int localCode = inChar - 0xAC00;
                    int jongCode = localCode % 28;
                    if (jongCode == 8 || jongCode == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            Regex _josaRegex = new Regex(@"\(이\)가|\(와\)과|\(을\)를|\(은\)는|\(아\)야|\(이\)여|\(으\)로|\(이\)라");

            Dictionary<string, JosaPair> _josaPatternPaird = new Dictionary<string, JosaPair>
            {
                { "(이)가", new JosaPair("이", "가") },
                { "(와)과", new JosaPair("과", "와") },
                { "(을)를", new JosaPair("을", "를") },
                { "(은)는", new JosaPair("은", "는") },
                { "(아)야", new JosaPair("아", "야") },
                { "(이)여", new JosaPair("이여", "여") },
                { "(으)로", new JosaPair("으로", "로") },
                { "(이)라", new JosaPair("이라", "라") },
            };

        }

        public static string ReplaceJosa(string src)
        {
            return _josa.Replace(src);
        }

        static Josa _josa = new Josa();
    }

}
