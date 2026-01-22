namespace MultiFileManager
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
            this.listLeft = new System.Windows.Forms.ListView();
            this.listRight = new System.Windows.Forms.ListView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.queuePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPause = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.btnSelectedTarget = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listLeft
            // 
            this.listLeft.AllowDrop = true;
            this.listLeft.BackColor = System.Drawing.Color.Black;
            this.listLeft.ForeColor = System.Drawing.Color.Red;
            this.listLeft.FullRowSelect = true;
            this.listLeft.GridLines = true;
            this.listLeft.HideSelection = false;
            this.listLeft.Location = new System.Drawing.Point(12, 12);
            this.listLeft.Name = "listLeft";
            this.listLeft.Size = new System.Drawing.Size(250, 457);
            this.listLeft.TabIndex = 0;
            this.listLeft.UseCompatibleStateImageBehavior = false;
            this.listLeft.View = System.Windows.Forms.View.Details;
            // 
            // listRight
            // 
            this.listRight.AllowDrop = true;
            this.listRight.BackColor = System.Drawing.Color.Black;
            this.listRight.ForeColor = System.Drawing.Color.Red;
            this.listRight.FullRowSelect = true;
            this.listRight.GridLines = true;
            this.listRight.HideSelection = false;
            this.listRight.Location = new System.Drawing.Point(268, 12);
            this.listRight.Name = "listRight";
            this.listRight.Size = new System.Drawing.Size(333, 457);
            this.listRight.TabIndex = 1;
            this.listRight.UseCompatibleStateImageBehavior = false;
            this.listRight.View = System.Windows.Forms.View.Details;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.LightGray;
            this.progressBar.ForeColor = System.Drawing.Color.Red;
            this.progressBar.Location = new System.Drawing.Point(12, 591);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(323, 23);
            this.progressBar.TabIndex = 4;
            // 
            // queuePanel
            // 
            this.queuePanel.BackColor = System.Drawing.Color.Black;
            this.queuePanel.ForeColor = System.Drawing.Color.Red;
            this.queuePanel.Location = new System.Drawing.Point(16, 475);
            this.queuePanel.Name = "queuePanel";
            this.queuePanel.Size = new System.Drawing.Size(319, 110);
            this.queuePanel.TabIndex = 5;
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Black;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPause.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPause.ForeColor = System.Drawing.Color.Red;
            this.btnPause.Location = new System.Drawing.Point(12, 691);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(298, 40);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Пауза/Продолжить";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBox.ForeColor = System.Drawing.Color.Red;
            this.logBox.Location = new System.Drawing.Point(341, 475);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(260, 322);
            this.logBox.TabIndex = 7;
            this.logBox.Text = "";
            // 
            // btnSelectedTarget
            // 
            this.btnSelectedTarget.BackColor = System.Drawing.Color.Black;
            this.btnSelectedTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectedTarget.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectedTarget.ForeColor = System.Drawing.Color.Red;
            this.btnSelectedTarget.Location = new System.Drawing.Point(12, 737);
            this.btnSelectedTarget.Name = "btnSelectedTarget";
            this.btnSelectedTarget.Size = new System.Drawing.Size(298, 42);
            this.btnSelectedTarget.TabIndex = 8;
            this.btnSelectedTarget.Text = "Папка назначения";
            this.btnSelectedTarget.UseVisualStyleBackColor = false;
            this.btnSelectedTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Noto Sans", 18F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Red;
            this.btnRefresh.Location = new System.Drawing.Point(12, 646);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(298, 39);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Black;
            this.txtSearch.ForeColor = System.Drawing.Color.Red;
            this.txtSearch.Location = new System.Drawing.Point(12, 620);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.ForeColor = System.Drawing.Color.Red;
            this.btnSearch.Location = new System.Drawing.Point(278, 620);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 21);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(613, 809);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSelectedTarget);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.queuePanel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listRight);
            this.Controls.Add(this.listLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Файловый менеджер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listLeft;
        private System.Windows.Forms.ListView listRight;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FlowLayoutPanel queuePanel;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button btnSelectedTarget;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}

