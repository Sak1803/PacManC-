namespace Pac_man
{
    partial class VentanaMenu
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
            this.BotonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BotonStart
            // 
            this.BotonStart.Location = new System.Drawing.Point(180, 236);
            this.BotonStart.Name = "BotonStart";
            this.BotonStart.Size = new System.Drawing.Size(100, 43);
            this.BotonStart.TabIndex = 0;
            this.BotonStart.Text = "Start";
            this.BotonStart.UseVisualStyleBackColor = true;
            this.BotonStart.Click += new System.EventHandler(this.BotonStart_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(473, 577);
            this.Controls.Add(this.BotonStart);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BotonStart;
    }
}