namespace FormLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelResult = new Label();
            buttonAnalyze = new Button();
            textBoxIP = new TextBox();
            SuspendLayout();
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelResult.Location = new Point(44, 93);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(79, 21);
            labelResult.TabIndex = 0;
            labelResult.Text = "Resultado";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.BackColor = SystemColors.ActiveBorder;
            buttonAnalyze.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAnalyze.Location = new Point(263, 45);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(91, 29);
            buttonAnalyze.TabIndex = 1;
            buttonAnalyze.Text = "Analizar";
            buttonAnalyze.UseVisualStyleBackColor = false;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // textBoxIP
            // 
            textBoxIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxIP.Location = new Point(44, 45);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(190, 29);
            textBoxIP.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxIP);
            Controls.Add(buttonAnalyze);
            Controls.Add(labelResult);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelResult;
        private Button buttonAnalyze;
        private TextBox textBoxIP;
    }
}
