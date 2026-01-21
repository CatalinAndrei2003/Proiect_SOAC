namespace WorkProjectV0._1
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
            this.NrBitiHG = new System.Windows.Forms.NumericUpDown();
            this.NrPerceptroni = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.rtbStatistici = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NrBitiHG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NrPerceptroni)).BeginInit();
            this.SuspendLayout();
            // 
            // NrBitiHG
            // 
            this.NrBitiHG.Location = new System.Drawing.Point(579, 172);
            this.NrBitiHG.Name = "NrBitiHG";
            this.NrBitiHG.Size = new System.Drawing.Size(120, 22);
            this.NrBitiHG.TabIndex = 0;
            // 
            // NrPerceptroni
            // 
            this.NrPerceptroni.Location = new System.Drawing.Point(579, 236);
            this.NrPerceptroni.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NrPerceptroni.Name = "NrPerceptroni";
            this.NrPerceptroni.Size = new System.Drawing.Size(120, 22);
            this.NrPerceptroni.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valoarea Lui k";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numar Perceptroni";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(597, 291);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartBtn_MouseClick);
            // 
            // rtbStatistici
            // 
            this.rtbStatistici.Location = new System.Drawing.Point(12, 12);
            this.rtbStatistici.Name = "rtbStatistici";
            this.rtbStatistici.Size = new System.Drawing.Size(437, 426);
            this.rtbStatistici.TabIndex = 5;
            this.rtbStatistici.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbStatistici);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NrPerceptroni);
            this.Controls.Add(this.NrBitiHG);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NrBitiHG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NrPerceptroni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NrBitiHG;
        private System.Windows.Forms.NumericUpDown NrPerceptroni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.RichTextBox rtbStatistici;
    }
}

