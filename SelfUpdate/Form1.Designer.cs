namespace SelfUpdate
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Renovate = new System.Windows.Forms.Button();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Renovate
            // 
            this.Renovate.Location = new System.Drawing.Point(102, 226);
            this.Renovate.Name = "Renovate";
            this.Renovate.Size = new System.Drawing.Size(75, 23);
            this.Renovate.TabIndex = 0;
            this.Renovate.Text = "Обновить";
            this.Renovate.UseVisualStyleBackColor = true;
            this.Renovate.Click += new System.EventHandler(this.Renovate_Click);
            // 
            // textBox_Version
            // 
            this.textBox_Version.Location = new System.Drawing.Point(12, 56);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.Size = new System.Drawing.Size(260, 20);
            this.textBox_Version.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(197, 226);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.textBox_Version);
            this.Controls.Add(this.Renovate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Renovate;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.Button Exit;
    }
}

