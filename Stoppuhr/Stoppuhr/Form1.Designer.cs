
namespace Stoppuhr
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button4 = new System.Windows.Forms.Button();
            this.start_BTN = new System.Windows.Forms.Button();
            this.Stop_BTN = new System.Windows.Forms.Button();
            this.Reset_BTN = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 223);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "Beenden";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // start_BTN
            // 
            this.start_BTN.Location = new System.Drawing.Point(12, 79);
            this.start_BTN.Name = "start_BTN";
            this.start_BTN.Size = new System.Drawing.Size(125, 42);
            this.start_BTN.TabIndex = 4;
            this.start_BTN.Text = "Start";
            this.start_BTN.UseVisualStyleBackColor = true;
            this.start_BTN.Click += new System.EventHandler(this.start_BTN_Click);
            // 
            // Stop_BTN
            // 
            this.Stop_BTN.Location = new System.Drawing.Point(12, 127);
            this.Stop_BTN.Name = "Stop_BTN";
            this.Stop_BTN.Size = new System.Drawing.Size(125, 42);
            this.Stop_BTN.TabIndex = 5;
            this.Stop_BTN.Text = "Stopp";
            this.Stop_BTN.UseVisualStyleBackColor = true;
            this.Stop_BTN.Click += new System.EventHandler(this.Stop_BTN_Click);
            // 
            // Reset_BTN
            // 
            this.Reset_BTN.Location = new System.Drawing.Point(12, 175);
            this.Reset_BTN.Name = "Reset_BTN";
            this.Reset_BTN.Size = new System.Drawing.Size(125, 42);
            this.Reset_BTN.TabIndex = 6;
            this.Reset_BTN.Text = "Reset";
            this.Reset_BTN.UseVisualStyleBackColor = true;
            this.Reset_BTN.Click += new System.EventHandler(this.Reset_BTN_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(303, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(125, 251);
            this.listBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "Zwischenzeit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reset_BTN);
            this.Controls.Add(this.Stop_BTN);
            this.Controls.Add(this.start_BTN);
            this.Controls.Add(this.button4);
            this.Name = "Form1";
            this.Text = "Stoppuhr";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button start_BTN;
        private System.Windows.Forms.Button Stop_BTN;
        private System.Windows.Forms.Button Reset_BTN;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}

