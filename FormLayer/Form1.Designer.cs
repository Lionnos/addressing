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
            textBoxSubnet = new TextBox();
            label1 = new Label();
            label2 = new Label();
            labelResultSubnet = new Label();
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
            buttonAnalyze.Location = new Point(608, 44);
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
            textBoxIP.Location = new Point(151, 45);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(190, 29);
            textBoxIP.TabIndex = 2;
            // 
            // textBoxSubnet
            // 
            textBoxSubnet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSubnet.Location = new Point(484, 45);
            textBoxSubnet.Name = "textBoxSubnet";
            textBoxSubnet.Size = new Size(69, 29);
            textBoxSubnet.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 48);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 4;
            label1.Text = "Dirección IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(396, 48);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 5;
            label2.Text = "Sub redes:";
            // 
            // labelResultSubnet
            // 
            labelResultSubnet.AutoSize = true;
            labelResultSubnet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelResultSubnet.Location = new Point(399, 93);
            labelResultSubnet.Name = "labelResultSubnet";
            labelResultSubnet.Size = new Size(79, 21);
            labelResultSubnet.TabIndex = 6;
            labelResultSubnet.Text = "Resultado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelResultSubnet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxSubnet);
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
        private TextBox textBoxSubnet;
        private Label label1;
        private Label label2;
        private Label labelResultSubnet;
    }
}
