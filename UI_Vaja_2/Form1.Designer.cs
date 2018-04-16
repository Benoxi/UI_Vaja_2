namespace UI_Vaja_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.LevelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Xcoord = new System.Windows.Forms.Label();
            this.Ycoord = new System.Windows.Forms.Label();
            this.WarningLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBox
            // 
            this.GameBox.Location = new System.Drawing.Point(7, 7);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(650, 650);
            this.GameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameBox.TabIndex = 0;
            this.GameBox.TabStop = false;
            this.GameBox.Click += new System.EventHandler(this.GameBox_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.Location = new System.Drawing.Point(675, 612);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(297, 37);
            this.PlayBtn.TabIndex = 1;
            this.PlayBtn.Text = "PLAY";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // LevelBox
            // 
            this.LevelBox.FormattingEnabled = true;
            this.LevelBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.LevelBox.Location = new System.Drawing.Point(757, 21);
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.Size = new System.Drawing.Size(215, 21);
            this.LevelBox.TabIndex = 2;
            this.LevelBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "LEVEL:";
            // 
            // Xcoord
            // 
            this.Xcoord.AutoSize = true;
            this.Xcoord.Location = new System.Drawing.Point(715, 98);
            this.Xcoord.Name = "Xcoord";
            this.Xcoord.Size = new System.Drawing.Size(13, 13);
            this.Xcoord.TabIndex = 4;
            this.Xcoord.Text = "0";
            this.Xcoord.Click += new System.EventHandler(this.label2_Click);
            // 
            // Ycoord
            // 
            this.Ycoord.AutoSize = true;
            this.Ycoord.Location = new System.Drawing.Point(715, 137);
            this.Ycoord.Name = "Ycoord";
            this.Ycoord.Size = new System.Drawing.Size(13, 13);
            this.Ycoord.TabIndex = 5;
            this.Ycoord.Text = "0";
            // 
            // WarningLbl
            // 
            this.WarningLbl.AutoSize = true;
            this.WarningLbl.Location = new System.Drawing.Point(675, 181);
            this.WarningLbl.Name = "WarningLbl";
            this.WarningLbl.Size = new System.Drawing.Size(0, 13);
            this.WarningLbl.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.WarningLbl);
            this.Controls.Add(this.Ycoord);
            this.Controls.Add(this.Xcoord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelBox);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.GameBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.ComboBox LevelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Xcoord;
        private System.Windows.Forms.Label Ycoord;
        private System.Windows.Forms.Label WarningLbl;
    }
}

