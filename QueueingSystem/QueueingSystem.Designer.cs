namespace QueueingSystem
{
    partial class QueueingSystemForm
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
            this.queueingSystemNameLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.showPictureBox = new System.Windows.Forms.PictureBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.modelingTimeLabel = new System.Windows.Forms.Label();
            this.modelingTimeTextBox = new System.Windows.Forms.TextBox();
            this.averageQueueTimeLabel = new System.Windows.Forms.Label();
            this.averagePeopleCountLabel = new System.Windows.Forms.Label();
            this.averageQueueTextBox = new System.Windows.Forms.TextBox();
            this.averagePeopleCountTextBox = new System.Windows.Forms.TextBox();
            this.averageTimeInSystemTextBox = new System.Windows.Forms.TextBox();
            this.averageTimesInSystemLabel = new System.Windows.Forms.Label();
            this.averageProcessTimeTextBox = new System.Windows.Forms.TextBox();
            this.averageProcessTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // queueingSystemNameLabel
            // 
            this.queueingSystemNameLabel.AutoSize = true;
            this.queueingSystemNameLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queueingSystemNameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.queueingSystemNameLabel.Location = new System.Drawing.Point(53, 9);
            this.queueingSystemNameLabel.Name = "queueingSystemNameLabel";
            this.queueingSystemNameLabel.Size = new System.Drawing.Size(707, 21);
            this.queueingSystemNameLabel.TabIndex = 0;
            this.queueingSystemNameLabel.Text = "Модель системы массового обслуживания с двумя последовательными устройствами";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.startButton.Location = new System.Drawing.Point(10, 82);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(222, 42);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Начать моделирование";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // showPictureBox
            // 
            this.showPictureBox.BackColor = System.Drawing.Color.Lavender;
            this.showPictureBox.Location = new System.Drawing.Point(238, 33);
            this.showPictureBox.Name = "showPictureBox";
            this.showPictureBox.Size = new System.Drawing.Size(550, 360);
            this.showPictureBox.TabIndex = 2;
            this.showPictureBox.TabStop = false;
            this.showPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.showPictureBox_Paint);
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.logLabel.Location = new System.Drawing.Point(81, 130);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(74, 19);
            this.logLabel.TabIndex = 3;
            this.logLabel.Text = "Действия";
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.Lavender;
            this.logTextBox.Location = new System.Drawing.Point(10, 161);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(221, 232);
            this.logTextBox.TabIndex = 4;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.stopButton.Location = new System.Drawing.Point(9, 82);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(222, 42);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Остановить моделирование";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // modelingTimeLabel
            // 
            this.modelingTimeLabel.AutoSize = true;
            this.modelingTimeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modelingTimeLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.modelingTimeLabel.Location = new System.Drawing.Point(12, 49);
            this.modelingTimeLabel.Name = "modelingTimeLabel";
            this.modelingTimeLabel.Size = new System.Drawing.Size(170, 19);
            this.modelingTimeLabel.TabIndex = 6;
            this.modelingTimeLabel.Text = "Период моделирования";
            // 
            // modelingTimeTextBox
            // 
            this.modelingTimeTextBox.Location = new System.Drawing.Point(188, 50);
            this.modelingTimeTextBox.Name = "modelingTimeTextBox";
            this.modelingTimeTextBox.Size = new System.Drawing.Size(42, 20);
            this.modelingTimeTextBox.TabIndex = 7;
            // 
            // averageQueueTimeLabel
            // 
            this.averageQueueTimeLabel.AutoSize = true;
            this.averageQueueTimeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averageQueueTimeLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.averageQueueTimeLabel.Location = new System.Drawing.Point(12, 443);
            this.averageQueueTimeLabel.Name = "averageQueueTimeLabel";
            this.averageQueueTimeLabel.Size = new System.Drawing.Size(248, 19);
            this.averageQueueTimeLabel.TabIndex = 10;
            this.averageQueueTimeLabel.Text = "Среднее время задержки в очереди";
            // 
            // averagePeopleCountLabel
            // 
            this.averagePeopleCountLabel.AutoSize = true;
            this.averagePeopleCountLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averagePeopleCountLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.averagePeopleCountLabel.Location = new System.Drawing.Point(457, 443);
            this.averagePeopleCountLabel.Name = "averagePeopleCountLabel";
            this.averagePeopleCountLabel.Size = new System.Drawing.Size(248, 19);
            this.averagePeopleCountLabel.TabIndex = 13;
            this.averagePeopleCountLabel.Text = "Среднее число клиентов в очереди";
            // 
            // averageQueueTextBox
            // 
            this.averageQueueTextBox.BackColor = System.Drawing.Color.Lavender;
            this.averageQueueTextBox.Location = new System.Drawing.Point(288, 444);
            this.averageQueueTextBox.Name = "averageQueueTextBox";
            this.averageQueueTextBox.ReadOnly = true;
            this.averageQueueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.averageQueueTextBox.Size = new System.Drawing.Size(42, 20);
            this.averageQueueTextBox.TabIndex = 14;
            // 
            // averagePeopleCountTextBox
            // 
            this.averagePeopleCountTextBox.BackColor = System.Drawing.Color.Lavender;
            this.averagePeopleCountTextBox.Location = new System.Drawing.Point(733, 444);
            this.averagePeopleCountTextBox.Name = "averagePeopleCountTextBox";
            this.averagePeopleCountTextBox.ReadOnly = true;
            this.averagePeopleCountTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.averagePeopleCountTextBox.Size = new System.Drawing.Size(42, 20);
            this.averagePeopleCountTextBox.TabIndex = 15;
            // 
            // averageTimeInSystemTextBox
            // 
            this.averageTimeInSystemTextBox.BackColor = System.Drawing.Color.Lavender;
            this.averageTimeInSystemTextBox.Location = new System.Drawing.Point(288, 409);
            this.averageTimeInSystemTextBox.Name = "averageTimeInSystemTextBox";
            this.averageTimeInSystemTextBox.ReadOnly = true;
            this.averageTimeInSystemTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.averageTimeInSystemTextBox.Size = new System.Drawing.Size(42, 20);
            this.averageTimeInSystemTextBox.TabIndex = 17;
            // 
            // averageTimesInSystemLabel
            // 
            this.averageTimesInSystemLabel.AutoSize = true;
            this.averageTimesInSystemLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averageTimesInSystemLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.averageTimesInSystemLabel.Location = new System.Drawing.Point(12, 408);
            this.averageTimesInSystemLabel.Name = "averageTimesInSystemLabel";
            this.averageTimesInSystemLabel.Size = new System.Drawing.Size(180, 19);
            this.averageTimesInSystemLabel.TabIndex = 16;
            this.averageTimesInSystemLabel.Text = "Среднее время в системе";
            // 
            // averageProcessTimeTextBox
            // 
            this.averageProcessTimeTextBox.BackColor = System.Drawing.Color.Lavender;
            this.averageProcessTimeTextBox.Location = new System.Drawing.Point(733, 409);
            this.averageProcessTimeTextBox.Name = "averageProcessTimeTextBox";
            this.averageProcessTimeTextBox.ReadOnly = true;
            this.averageProcessTimeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.averageProcessTimeTextBox.Size = new System.Drawing.Size(42, 20);
            this.averageProcessTimeTextBox.TabIndex = 19;
            // 
            // averageProcessTimeLabel
            // 
            this.averageProcessTimeLabel.AutoSize = true;
            this.averageProcessTimeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averageProcessTimeLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.averageProcessTimeLabel.Location = new System.Drawing.Point(457, 408);
            this.averageProcessTimeLabel.Name = "averageProcessTimeLabel";
            this.averageProcessTimeLabel.Size = new System.Drawing.Size(212, 19);
            this.averageProcessTimeLabel.TabIndex = 18;
            this.averageProcessTimeLabel.Text = "Среднее время обслуживания";
            // 
            // QueueingSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.averageProcessTimeTextBox);
            this.Controls.Add(this.averageProcessTimeLabel);
            this.Controls.Add(this.averageTimeInSystemTextBox);
            this.Controls.Add(this.averageTimesInSystemLabel);
            this.Controls.Add(this.averagePeopleCountTextBox);
            this.Controls.Add(this.averageQueueTextBox);
            this.Controls.Add(this.averagePeopleCountLabel);
            this.Controls.Add(this.averageQueueTimeLabel);
            this.Controls.Add(this.modelingTimeTextBox);
            this.Controls.Add(this.modelingTimeLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.showPictureBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.queueingSystemNameLabel);
            this.Name = "QueueingSystemForm";
            this.Text = "Система массового обслуживания";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueueingSystemForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label queueingSystemNameLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox showPictureBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label modelingTimeLabel;
        private System.Windows.Forms.TextBox modelingTimeTextBox;
        private System.Windows.Forms.Label averageQueueTimeLabel;
        private System.Windows.Forms.Label averagePeopleCountLabel;
        private System.Windows.Forms.TextBox averageQueueTextBox;
        private System.Windows.Forms.TextBox averagePeopleCountTextBox;
        private System.Windows.Forms.TextBox averageTimeInSystemTextBox;
        private System.Windows.Forms.Label averageTimesInSystemLabel;
        private System.Windows.Forms.TextBox averageProcessTimeTextBox;
        private System.Windows.Forms.Label averageProcessTimeLabel;
    }
}

