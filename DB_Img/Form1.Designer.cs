namespace DB_Img
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
            this.Button_LoadImg = new System.Windows.Forms.Button();
            this.Button_SaveDB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox_Num = new System.Windows.Forms.TextBox();
            this.textBox_ImgPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_Select = new System.Windows.Forms.ComboBox();
            this.Button_DeleteCombo = new System.Windows.Forms.Button();
            this.Button_DeleteDGV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_LoadImg
            // 
            this.Button_LoadImg.Location = new System.Drawing.Point(285, 270);
            this.Button_LoadImg.Name = "Button_LoadImg";
            this.Button_LoadImg.Size = new System.Drawing.Size(75, 23);
            this.Button_LoadImg.TabIndex = 0;
            this.Button_LoadImg.Text = "불러오기";
            this.Button_LoadImg.UseVisualStyleBackColor = true;
            this.Button_LoadImg.Click += new System.EventHandler(this.Button_LoadImg_Click);
            // 
            // Button_SaveDB
            // 
            this.Button_SaveDB.Location = new System.Drawing.Point(285, 299);
            this.Button_SaveDB.Name = "Button_SaveDB";
            this.Button_SaveDB.Size = new System.Drawing.Size(75, 23);
            this.Button_SaveDB.TabIndex = 1;
            this.Button_SaveDB.Text = "저장하기";
            this.Button_SaveDB.UseVisualStyleBackColor = true;
            this.Button_SaveDB.Click += new System.EventHandler(this.Button_SaveDB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(60, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Location = new System.Drawing.Point(450, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // textBox_Num
            // 
            this.textBox_Num.Location = new System.Drawing.Point(142, 297);
            this.textBox_Num.Name = "textBox_Num";
            this.textBox_Num.Size = new System.Drawing.Size(100, 21);
            this.textBox_Num.TabIndex = 4;
            // 
            // textBox_ImgPath
            // 
            this.textBox_ImgPath.Location = new System.Drawing.Point(60, 270);
            this.textBox_ImgPath.Name = "textBox_ImgPath";
            this.textBox_ImgPath.Size = new System.Drawing.Size(182, 21);
            this.textBox_ImgPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "이미지 파일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "이미지 파일";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(450, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(150, 150);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // comboBox_Select
            // 
            this.comboBox_Select.FormattingEnabled = true;
            this.comboBox_Select.Location = new System.Drawing.Point(610, 266);
            this.comboBox_Select.Name = "comboBox_Select";
            this.comboBox_Select.Size = new System.Drawing.Size(140, 20);
            this.comboBox_Select.TabIndex = 10;
            this.comboBox_Select.SelectedIndexChanged += new System.EventHandler(this.comboBox_Select_SelectedIndexChanged);
            // 
            // Button_DeleteCombo
            // 
            this.Button_DeleteCombo.Location = new System.Drawing.Point(167, 324);
            this.Button_DeleteCombo.Name = "Button_DeleteCombo";
            this.Button_DeleteCombo.Size = new System.Drawing.Size(75, 23);
            this.Button_DeleteCombo.TabIndex = 12;
            this.Button_DeleteCombo.Text = "콤보 삭제";
            this.Button_DeleteCombo.UseVisualStyleBackColor = true;
            this.Button_DeleteCombo.Click += new System.EventHandler(this.Button_DeleteCombo_Click);
            // 
            // Button_DeleteDGV
            // 
            this.Button_DeleteDGV.Location = new System.Drawing.Point(167, 353);
            this.Button_DeleteDGV.Name = "Button_DeleteDGV";
            this.Button_DeleteDGV.Size = new System.Drawing.Size(75, 23);
            this.Button_DeleteDGV.TabIndex = 13;
            this.Button_DeleteDGV.Text = "뷰 삭제";
            this.Button_DeleteDGV.UseVisualStyleBackColor = true;
            this.Button_DeleteDGV.Click += new System.EventHandler(this.Button_DeleteDGV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_DeleteDGV);
            this.Controls.Add(this.Button_DeleteCombo);
            this.Controls.Add(this.comboBox_Select);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ImgPath);
            this.Controls.Add(this.textBox_Num);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Button_SaveDB);
            this.Controls.Add(this.Button_LoadImg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_LoadImg;
        private System.Windows.Forms.Button Button_SaveDB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox_Num;
        private System.Windows.Forms.TextBox textBox_ImgPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_Select;
        private System.Windows.Forms.Button Button_DeleteCombo;
        private System.Windows.Forms.Button Button_DeleteDGV;
    }
}

