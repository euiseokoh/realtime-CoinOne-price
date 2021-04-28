namespace Coin_robo
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox5
            // 
            this.GroupBox5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox5.Controls.Add(this.button1);
            this.GroupBox5.Controls.Add(this.button5);
            this.GroupBox5.Controls.Add(this.button4);
            this.GroupBox5.Controls.Add(this.button3);
            this.GroupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GroupBox5.Location = new System.Drawing.Point(3, 3);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(1502, 60);
            this.GroupBox5.TabIndex = 9;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "로그인";
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(371, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 23);
            this.button5.TabIndex = 31;
            this.button5.Text = "종목";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(283, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 30;
            this.button4.Text = "시황";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(156, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "실시간 감시";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox4.Controls.Add(this.lbLog);
            this.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GroupBox4.Location = new System.Drawing.Point(3, 541);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(1502, 270);
            this.GroupBox4.TabIndex = 8;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "로그";
            // 
            // lbLog
            // 
            this.lbLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 12;
            this.lbLog.Location = new System.Drawing.Point(6, 20);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(1480, 232);
            this.lbLog.TabIndex = 0;
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox3.Controls.Add(this.DataGridView1);
            this.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GroupBox3.Location = new System.Drawing.Point(3, 69);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(1502, 475);
            this.GroupBox3.TabIndex = 7;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "시세바 - 매초 갱신";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column11,
            this.Column13,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column4,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(3, 17);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 15;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(1496, 455);
            this.DataGridView1.TabIndex = 0;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "가상화폐";
            this.Column12.Name = "Column12";
            this.Column12.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "가상화폐명";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "시작가";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "현재가";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "등락폭";
            this.Column11.Name = "Column11";
            this.Column11.Width = 80;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "수익률";
            this.Column13.Name = "Column13";
            this.Column13.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "당일저가";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "당일고가";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "당일평균가";
            this.Column7.Name = "Column7";
            this.Column7.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "당일거래량";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "전일거래량";
            this.Column8.Name = "Column8";
            this.Column8.Width = 120;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "전일고가";
            this.Column9.Name = "Column9";
            this.Column9.Width = 120;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "거래금액";
            this.Column10.Name = "Column10";
            this.Column10.Width = 160;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(29, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "현재가 요청";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 814);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.ListBox lbLog;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        internal System.Windows.Forms.Button button1;
    }
}

