namespace DataReader
{
    partial class Principale
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
            this.btnPorte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPorte
            // 
            this.btnPorte.Location = new System.Drawing.Point(213, 107);
            this.btnPorte.Name = "btnPorte";
            this.btnPorte.Size = new System.Drawing.Size(164, 99);
            this.btnPorte.TabIndex = 0;
            this.btnPorte.Text = "Apertura Porte";
            this.btnPorte.UseVisualStyleBackColor = true;
            this.btnPorte.Click += new System.EventHandler(this.BtnPorte_Click);
            // 
            // Principale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 348);
            this.Controls.Add(this.btnPorte);
            this.Name = "Principale";
            this.Text = "Principale";
            this.Load += new System.EventHandler(this.Principale_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPorte;
    }
}