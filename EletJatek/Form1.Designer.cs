namespace EletJatek
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.Meret = new System.Windows.Forms.NumericUpDown();
            this.OKGomb = new System.Windows.Forms.Button();
            this.panelGame = new System.Windows.Forms.Panel();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Meret)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.controlPanel.Controls.Add(this.Meret);
            this.controlPanel.Controls.Add(this.OKGomb);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(800, 71);
            this.controlPanel.TabIndex = 0;
            // 
            // Meret
            // 
            this.Meret.Location = new System.Drawing.Point(740, 21);
            this.Meret.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Meret.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Meret.Name = "Meret";
            this.Meret.Size = new System.Drawing.Size(120, 20);
            this.Meret.TabIndex = 1;
            this.Meret.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // OKGomb
            // 
            this.OKGomb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OKGomb.Location = new System.Drawing.Point(870, 20);
            this.OKGomb.Name = "OKGomb";
            this.OKGomb.Size = new System.Drawing.Size(75, 23);
            this.OKGomb.TabIndex = 0;
            this.OKGomb.Text = "OK";
            this.OKGomb.UseVisualStyleBackColor = true;
            this.OKGomb.Click += new System.EventHandler(this.Start);
            // 
            // panelGame
            // 
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 71);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(800, 379);
            this.panelGame.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.controlPanel);
            this.Name = "Form1";
            this.Text = "Élet Játék";
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Meret)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button OKGomb;
        private System.Windows.Forms.NumericUpDown Meret;
    }
}

