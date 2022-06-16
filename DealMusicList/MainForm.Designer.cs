namespace DealMusicList
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btExec = new System.Windows.Forms.Button();
            this.btPath = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cbIdentity = new System.Windows.Forms.CheckBox();
            this.Dddigit = new System.Windows.Forms.DomainUpDown();
            this.lbdigit = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataAnay = new System.Windows.Forms.RichTextBox();
            this.dgvfolderlist = new System.Windows.Forms.DataGridView();
            this.CoForder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfolderlist)).BeginInit();
            this.SuspendLayout();
            // 
            // btExec
            // 
            this.btExec.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btExec.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btExec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btExec.Location = new System.Drawing.Point(548, 186);
            this.btExec.Name = "btExec";
            this.btExec.Size = new System.Drawing.Size(128, 62);
            this.btExec.TabIndex = 9;
            this.btExec.Text = "重新排序";
            this.btExec.UseVisualStyleBackColor = false;
            this.btExec.Click += new System.EventHandler(this.BtExec_Click);
            // 
            // btPath
            // 
            this.btPath.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btPath.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btPath.Location = new System.Drawing.Point(601, 16);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(75, 33);
            this.btPath.TabIndex = 7;
            this.btPath.Text = "瀏 覽";
            this.btPath.UseVisualStyleBackColor = false;
            this.btPath.Click += new System.EventHandler(this.BtPath_Click);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbPath.Location = new System.Drawing.Point(15, 22);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(39, 19);
            this.lbPath.TabIndex = 6;
            this.lbPath.Text = "路徑";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPath.Location = new System.Drawing.Point(61, 19);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(534, 27);
            this.txtPath.TabIndex = 5;
            // 
            // cbIdentity
            // 
            this.cbIdentity.AutoSize = true;
            this.cbIdentity.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbIdentity.Location = new System.Drawing.Point(558, 68);
            this.cbIdentity.Name = "cbIdentity";
            this.cbIdentity.Size = new System.Drawing.Size(118, 23);
            this.cbIdentity.TabIndex = 11;
            this.cbIdentity.Text = "是否有識別碼";
            this.cbIdentity.UseVisualStyleBackColor = true;
            this.cbIdentity.CheckedChanged += new System.EventHandler(this.CbIdentity_CheckedChanged);
            // 
            // Dddigit
            // 
            this.Dddigit.BackColor = System.Drawing.Color.White;
            this.Dddigit.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dddigit.Items.Add("1");
            this.Dddigit.Items.Add("2");
            this.Dddigit.Items.Add("3");
            this.Dddigit.Items.Add("4");
            this.Dddigit.Items.Add("5");
            this.Dddigit.Location = new System.Drawing.Point(612, 110);
            this.Dddigit.Name = "Dddigit";
            this.Dddigit.ReadOnly = true;
            this.Dddigit.Size = new System.Drawing.Size(64, 25);
            this.Dddigit.TabIndex = 12;
            this.Dddigit.Text = "3";
            this.Dddigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dddigit.SelectedItemChanged += new System.EventHandler(this.Dddigit_SelectedItemChanged);
            // 
            // lbdigit
            // 
            this.lbdigit.AutoSize = true;
            this.lbdigit.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbdigit.Location = new System.Drawing.Point(534, 112);
            this.lbdigit.Name = "lbdigit";
            this.lbdigit.Size = new System.Drawing.Size(69, 19);
            this.lbdigit.TabIndex = 13;
            this.lbdigit.Text = "編碼位數";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(423, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "使用說明";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(466, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Version 1.0.0 Copyright © Rick Lin.";
            // 
            // txtDataAnay
            // 
            this.txtDataAnay.BackColor = System.Drawing.Color.White;
            this.txtDataAnay.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDataAnay.Location = new System.Drawing.Point(12, 68);
            this.txtDataAnay.Name = "txtDataAnay";
            this.txtDataAnay.ReadOnly = true;
            this.txtDataAnay.Size = new System.Drawing.Size(405, 268);
            this.txtDataAnay.TabIndex = 16;
            this.txtDataAnay.Text = "";
            // 
            // dgvfolderlist
            // 
            this.dgvfolderlist.AllowUserToAddRows = false;
            this.dgvfolderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfolderlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoForder,
            this.CoSpace,
            this.CoByte});
            this.dgvfolderlist.Location = new System.Drawing.Point(12, 342);
            this.dgvfolderlist.Name = "dgvfolderlist";
            this.dgvfolderlist.RowTemplate.Height = 24;
            this.dgvfolderlist.Size = new System.Drawing.Size(672, 347);
            this.dgvfolderlist.TabIndex = 17;
            this.dgvfolderlist.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgvfolderlist_ColumnHeaderMouseClick);
            // 
            // CoForder
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CoForder.DefaultCellStyle = dataGridViewCellStyle1;
            this.CoForder.HeaderText = "資料夾名稱";
            this.CoForder.Name = "CoForder";
            this.CoForder.ReadOnly = true;
            this.CoForder.Width = 480;
            // 
            // CoSpace
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CoSpace.DefaultCellStyle = dataGridViewCellStyle2;
            this.CoSpace.HeaderText = "大小";
            this.CoSpace.Name = "CoSpace";
            this.CoSpace.ReadOnly = true;
            this.CoSpace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CoSpace.Width = 120;
            // 
            // CoByte
            // 
            this.CoByte.HeaderText = "位元組";
            this.CoByte.Name = "CoByte";
            this.CoByte.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 704);
            this.Controls.Add(this.dgvfolderlist);
            this.Controls.Add(this.txtDataAnay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbdigit);
            this.Controls.Add(this.Dddigit);
            this.Controls.Add(this.cbIdentity);
            this.Controls.Add(this.btExec);
            this.Controls.Add(this.btPath);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.txtPath);
            this.Font = new System.Drawing.Font("新細明體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "歌曲排序軟體";
            ((System.ComponentModel.ISupportInitialize)(this.dgvfolderlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExec;
        private System.Windows.Forms.Button btPath;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.CheckBox cbIdentity;
        private System.Windows.Forms.DomainUpDown Dddigit;
        private System.Windows.Forms.Label lbdigit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDataAnay;
        private System.Windows.Forms.DataGridView dgvfolderlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoForder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoByte;
    }
}

