namespace Voice_Calculator
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.FirstNextBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Roboto Slab", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 141);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello, welcome to Voice Calculator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstNextBtn
            // 
            this.FirstNextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstNextBtn.Font = new System.Drawing.Font("Roboto Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNextBtn.Location = new System.Drawing.Point(363, 238);
            this.FirstNextBtn.Name = "FirstNextBtn";
            this.FirstNextBtn.Size = new System.Drawing.Size(139, 51);
            this.FirstNextBtn.TabIndex = 1;
            this.FirstNextBtn.Text = "Next";
            this.FirstNextBtn.UseVisualStyleBackColor = true;
            this.FirstNextBtn.Click += new System.EventHandler(this.FirstNextBtn_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 301);
            this.Controls.Add(this.FirstNextBtn);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(530, 340);
            this.MinimumSize = new System.Drawing.Size(330, 340);
            this.Name = "Welcome";
            this.Text = "Voice Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FirstNextBtn;
    }
}

