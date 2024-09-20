namespace RedisManage
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
			treeRedisList = new TreeView();
			rtbRedisContent = new RichTextBox();
			lblRedisName = new Label();
			btnDelRedis = new Button();
			lblKeyName = new Label();
			label1 = new Label();
			label2 = new Label();
			txtKey = new TextBox();
			btnSearch = new Button();
			button1 = new Button();
			SuspendLayout();
			// 
			// treeRedisList
			// 
			treeRedisList.Location = new Point(6, 59);
			treeRedisList.Name = "treeRedisList";
			treeRedisList.Size = new Size(404, 713);
			treeRedisList.TabIndex = 0;
			treeRedisList.AfterSelect += treeRedisList_AfterSelect;
			treeRedisList.Click += treeRedisList_Click;
			// 
			// rtbRedisContent
			// 
			rtbRedisContent.Location = new Point(416, 89);
			rtbRedisContent.Name = "rtbRedisContent";
			rtbRedisContent.Size = new Size(878, 683);
			rtbRedisContent.TabIndex = 1;
			rtbRedisContent.Text = "";
			// 
			// lblRedisName
			// 
			lblRedisName.AutoSize = true;
			lblRedisName.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblRedisName.Location = new Point(416, 20);
			lblRedisName.Name = "lblRedisName";
			lblRedisName.Size = new Size(170, 21);
			lblRedisName.TabIndex = 2;
			lblRedisName.Text = "当前查看的缓存名称：";
			// 
			// btnDelRedis
			// 
			btnDelRedis.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnDelRedis.Location = new Point(918, 22);
			btnDelRedis.Name = "btnDelRedis";
			btnDelRedis.Size = new Size(131, 34);
			btnDelRedis.TabIndex = 3;
			btnDelRedis.Text = "删除该缓存";
			btnDelRedis.UseVisualStyleBackColor = true;
			btnDelRedis.Click += btnDelRedis_Click;
			// 
			// lblKeyName
			// 
			lblKeyName.AutoSize = true;
			lblKeyName.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblKeyName.Location = new Point(592, 23);
			lblKeyName.Name = "lblKeyName";
			lblKeyName.Size = new Size(83, 21);
			lblKeyName.TabIndex = 4;
			lblKeyName.Text = "KeyName";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(417, 59);
			label1.Name = "label1";
			label1.Size = new Size(90, 21);
			label1.TabIndex = 5;
			label1.Text = "缓存内容：";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(8, 25);
			label2.Name = "label2";
			label2.Size = new Size(44, 17);
			label2.TabIndex = 6;
			label2.Text = "搜索：";
			// 
			// txtKey
			// 
			txtKey.Location = new Point(58, 24);
			txtKey.Name = "txtKey";
			txtKey.Size = new Size(224, 23);
			txtKey.TabIndex = 7;
			// 
			// btnSearch
			// 
			btnSearch.Location = new Point(289, 22);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(75, 28);
			btnSearch.TabIndex = 8;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// button1
			// 
			button1.Location = new Point(1055, 22);
			button1.Name = "button1";
			button1.Size = new Size(94, 34);
			button1.TabIndex = 9;
			button1.Text = "清除所有缓存";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1306, 784);
			Controls.Add(button1);
			Controls.Add(btnSearch);
			Controls.Add(txtKey);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lblKeyName);
			Controls.Add(btnDelRedis);
			Controls.Add(lblRedisName);
			Controls.Add(rtbRedisContent);
			Controls.Add(treeRedisList);
			Name = "Form1";
			Text = "缓存管理V1.0";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TreeView treeRedisList;
        private RichTextBox rtbRedisContent;
        private Label lblRedisName;
        private Button btnDelRedis;
        private Label lblKeyName;
        private Label label1;
        private Label label2;
        private TextBox txtKey;
        private Button btnSearch;
		private Button button1;
	}
}