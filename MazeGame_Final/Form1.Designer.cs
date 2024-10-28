namespace MazeGame_Final
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.easy_Btn = new System.Windows.Forms.Button();
            this.med_Btn = new System.Windows.Forms.Button();
            this.hard_Btn = new System.Windows.Forms.Button();
            this.intro_Btn = new System.Windows.Forms.Button();
            this.exit_Btn = new System.Windows.Forms.Button();
            this.WinnerHis_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easy_Btn
            // 
            this.easy_Btn.BackColor = System.Drawing.Color.Gray;
            this.easy_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.easy_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.easy_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easy_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.easy_Btn.Location = new System.Drawing.Point(324, 210);
            this.easy_Btn.Name = "easy_Btn";
            this.easy_Btn.Size = new System.Drawing.Size(135, 53);
            this.easy_Btn.TabIndex = 0;
            this.easy_Btn.Text = "Dễ";
            this.easy_Btn.UseVisualStyleBackColor = false;
            this.easy_Btn.Click += new System.EventHandler(this.EasyLevelClick);
            // 
            // med_Btn
            // 
            this.med_Btn.BackColor = System.Drawing.Color.Gray;
            this.med_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.med_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.med_Btn.ForeColor = System.Drawing.Color.Transparent;
            this.med_Btn.Location = new System.Drawing.Point(324, 269);
            this.med_Btn.Name = "med_Btn";
            this.med_Btn.Size = new System.Drawing.Size(135, 53);
            this.med_Btn.TabIndex = 1;
            this.med_Btn.Text = "Thường";
            this.med_Btn.UseVisualStyleBackColor = false;
            this.med_Btn.Click += new System.EventHandler(this.MediumLevelClick);
            // 
            // hard_Btn
            // 
            this.hard_Btn.BackColor = System.Drawing.Color.Gray;
            this.hard_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hard_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hard_Btn.ForeColor = System.Drawing.Color.Transparent;
            this.hard_Btn.Location = new System.Drawing.Point(324, 328);
            this.hard_Btn.Name = "hard_Btn";
            this.hard_Btn.Size = new System.Drawing.Size(135, 53);
            this.hard_Btn.TabIndex = 2;
            this.hard_Btn.Text = "Khó";
            this.hard_Btn.UseVisualStyleBackColor = false;
            this.hard_Btn.Click += new System.EventHandler(this.HardLevelClick);
            // 
            // intro_Btn
            // 
            this.intro_Btn.BackColor = System.Drawing.Color.Gray;
            this.intro_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.intro_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intro_Btn.ForeColor = System.Drawing.Color.Transparent;
            this.intro_Btn.Location = new System.Drawing.Point(324, 387);
            this.intro_Btn.Name = "intro_Btn";
            this.intro_Btn.Size = new System.Drawing.Size(135, 53);
            this.intro_Btn.TabIndex = 3;
            this.intro_Btn.Text = "Giới thiệu";
            this.intro_Btn.UseVisualStyleBackColor = false;
            this.intro_Btn.Click += new System.EventHandler(this.IntroClick);
            // 
            // exit_Btn
            // 
            this.exit_Btn.BackColor = System.Drawing.Color.Gray;
            this.exit_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_Btn.ForeColor = System.Drawing.Color.White;
            this.exit_Btn.Location = new System.Drawing.Point(23, 550);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(72, 38);
            this.exit_Btn.TabIndex = 4;
            this.exit_Btn.Text = "Thoát";
            this.exit_Btn.UseVisualStyleBackColor = false;
            this.exit_Btn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // WinnerHis_Btn
            // 
            this.WinnerHis_Btn.BackColor = System.Drawing.Color.Gray;
            this.WinnerHis_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WinnerHis_Btn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerHis_Btn.ForeColor = System.Drawing.Color.White;
            this.WinnerHis_Btn.Location = new System.Drawing.Point(101, 550);
            this.WinnerHis_Btn.Name = "WinnerHis_Btn";
            this.WinnerHis_Btn.Size = new System.Drawing.Size(219, 38);
            this.WinnerHis_Btn.TabIndex = 5;
            this.WinnerHis_Btn.Text = "Lịch sử chiến thắng";
            this.WinnerHis_Btn.UseVisualStyleBackColor = false;
            this.WinnerHis_Btn.Click += new System.EventHandler(this.WinnerHis_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MazeGame_Final.Properties.Resources.backGroundMenu2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 600);
            this.Controls.Add(this.WinnerHis_Btn);
            this.Controls.Add(this.exit_Btn);
            this.Controls.Add(this.intro_Btn);
            this.Controls.Add(this.hard_Btn);
            this.Controls.Add(this.med_Btn);
            this.Controls.Add(this.easy_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "EpicGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easy_Btn;
        private System.Windows.Forms.Button med_Btn;
        private System.Windows.Forms.Button hard_Btn;
        private System.Windows.Forms.Button intro_Btn;
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.Button WinnerHis_Btn;
    }
}

