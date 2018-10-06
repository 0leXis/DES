namespace DESFullScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonEncr = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxRes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDecr = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEncr
            // 
            this.buttonEncr.Location = new System.Drawing.Point(8, 114);
            this.buttonEncr.Name = "buttonEncr";
            this.buttonEncr.Size = new System.Drawing.Size(91, 23);
            this.buttonEncr.TabIndex = 0;
            this.buttonEncr.Text = "Зашифровать";
            this.buttonEncr.UseVisualStyleBackColor = true;
            this.buttonEncr.Click += new System.EventHandler(this.buttonEncr_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Location = new System.Drawing.Point(77, 60);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(620, 20);
            this.textBoxMsg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сообщение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ключ";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(77, 86);
            this.textBoxKey.MaxLength = 8;
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(620, 20);
            this.textBoxKey.TabIndex = 4;
            // 
            // textBoxRes
            // 
            this.textBoxRes.Location = new System.Drawing.Point(48, 143);
            this.textBoxRes.Name = "textBoxRes";
            this.textBoxRes.Size = new System.Drawing.Size(649, 20);
            this.textBoxRes.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ответ";
            // 
            // buttonDecr
            // 
            this.buttonDecr.Location = new System.Drawing.Point(105, 114);
            this.buttonDecr.Name = "buttonDecr";
            this.buttonDecr.Size = new System.Drawing.Size(91, 23);
            this.buttonDecr.TabIndex = 7;
            this.buttonDecr.Text = "Расшифровать";
            this.buttonDecr.UseVisualStyleBackColor = true;
            this.buttonDecr.Click += new System.EventHandler(this.buttonDecr_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Лог";
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLog.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxLog.Location = new System.Drawing.Point(49, 171);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(648, 297);
            this.textBoxLog.TabIndex = 9;
            this.textBoxLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLog_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(202, 118);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(260, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Отображать в логе каждый цикл шифрования";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(468, 118);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(221, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Отображать в логе генерацию ключей";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(658, 48);
            this.label5.TabIndex = 12;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 480);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDecr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRes);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.buttonEncr);
            this.Name = "Form1";
            this.Text = "Data Encryption Standard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEncr;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxRes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDecr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
    }
}

