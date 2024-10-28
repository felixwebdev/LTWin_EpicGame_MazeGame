namespace MazeGame_Final
{
    partial class historyWinner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(historyWinner));
            this.txtWinner = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWinner
            // 
            this.txtWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWinner.Location = new System.Drawing.Point(182, 139);
            this.txtWinner.Multiline = true;
            this.txtWinner.Name = "txtWinner";
            this.txtWinner.ReadOnly = true;
            this.txtWinner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWinner.Size = new System.Drawing.Size(461, 233);
            this.txtWinner.TabIndex = 0;
            // 
            // historyWinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MazeGame_Final.Properties.Resources.intro_back_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtWinner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "historyWinner";
            this.Text = "EpicGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWinner;
    }
}