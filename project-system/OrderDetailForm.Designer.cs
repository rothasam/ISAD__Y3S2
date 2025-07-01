namespace project_system
{
    partial class OrderDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsvImpDetail = new System.Windows.Forms.ListView();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInStockPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCusID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStaffID = new System.Windows.Forms.ComboBox();
            this.dtpImpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(327, 630);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 42);
            this.btnSave.TabIndex = 89;
            this.btnSave.Text = "រក្សាទុក";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(401, 566);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 25);
            this.label11.TabIndex = 87;
            this.label11.Text = "តម្លៃសរុប";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(483, 558);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(177, 33);
            this.txtTotal.TabIndex = 86;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::project_system.Properties.Resources.close;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(545, 634);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExit.Size = new System.Drawing.Size(115, 33);
            this.btnExit.TabIndex = 85;
            this.btnExit.Text = "ចាកចេញ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::project_system.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(179, 634);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAdd.Size = new System.Drawing.Size(109, 33);
            this.btnAdd.TabIndex = 82;
            this.btnAdd.Text = "បញ្ចូល";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lsvImpDetail
            // 
            this.lsvImpDetail.Font = new System.Drawing.Font("Noto Sans Khmer", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvImpDetail.FullRowSelect = true;
            this.lsvImpDetail.HideSelection = false;
            this.lsvImpDetail.Location = new System.Drawing.Point(59, 403);
            this.lsvImpDetail.Name = "lsvImpDetail";
            this.lsvImpDetail.Size = new System.Drawing.Size(601, 134);
            this.lsvImpDetail.TabIndex = 81;
            this.lsvImpDetail.UseCompatibleStateImageBehavior = false;
            // 
            // txtCusName
            // 
            this.txtCusName.AcceptsReturn = true;
            this.txtCusName.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.Location = new System.Drawing.Point(216, 234);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.Size = new System.Drawing.Size(158, 33);
            this.txtCusName.TabIndex = 80;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(416, 138);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(177, 33);
            this.txtStaffName.TabIndex = 79;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Image = global::project_system.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(63, 634);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRemove.Size = new System.Drawing.Size(99, 33);
            this.btnRemove.TabIndex = 88;
            this.btnRemove.Text = "លុប";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(411, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 25);
            this.label10.TabIndex = 78;
            this.label10.Text = "ឈ្មោះបុគ្គលិក";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 25);
            this.label9.TabIndex = 77;
            this.label9.Text = "អត្តលេខអតិថិជន";
            // 
            // txtInStockPrice
            // 
            this.txtInStockPrice.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInStockPrice.Location = new System.Drawing.Point(511, 346);
            this.txtInStockPrice.Name = "txtInStockPrice";
            this.txtInStockPrice.Size = new System.Drawing.Size(126, 33);
            this.txtInStockPrice.TabIndex = 76;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(506, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 25);
            this.label8.TabIndex = 75;
            this.label8.Text = "តម្លៃ";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(378, 346);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(118, 33);
            this.txtQty.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(373, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 73;
            this.label6.Text = "បរិមាណ";
            // 
            // txtPro
            // 
            this.txtPro.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPro.Location = new System.Drawing.Point(179, 346);
            this.txtPro.Name = "txtPro";
            this.txtPro.Size = new System.Drawing.Size(177, 33);
            this.txtPro.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(174, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 71;
            this.label5.Text = "ឈ្មោះ";
            // 
            // txtProID
            // 
            this.txtProID.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProID.Location = new System.Drawing.Point(59, 346);
            this.txtProID.Name = "txtProID";
            this.txtProID.Size = new System.Drawing.Size(103, 33);
            this.txtProID.TabIndex = 70;
            this.txtProID.TextChanged += new System.EventHandler(this.txtProID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(58, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 69;
            this.label4.Text = "លេខកូដ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 68;
            this.label3.Text = "ឈ្មោះអតិថិជន";
            // 
            // cboCusID
            // 
            this.cboCusID.Font = new System.Drawing.Font("Noto Sans Cham", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCusID.FormattingEnabled = true;
            this.cboCusID.Location = new System.Drawing.Point(58, 235);
            this.cboCusID.Name = "cboCusID";
            this.cboCusID.Size = new System.Drawing.Size(126, 32);
            this.cboCusID.TabIndex = 67;
            this.cboCusID.SelectionChangeCommitted += new System.EventHandler(this.cboCusID_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "អត្តលេខបុគ្គលិក";
            // 
            // cboStaffID
            // 
            this.cboStaffID.Font = new System.Drawing.Font("Noto Sans Cham", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStaffID.FormattingEnabled = true;
            this.cboStaffID.Location = new System.Drawing.Point(230, 142);
            this.cboStaffID.Name = "cboStaffID";
            this.cboStaffID.Size = new System.Drawing.Size(144, 32);
            this.cboStaffID.TabIndex = 65;
            this.cboStaffID.SelectionChangeCommitted += new System.EventHandler(this.cboStaffID_SelectionChangeCommitted);
            // 
            // dtpImpDate
            // 
            this.dtpImpDate.CustomFormat = "MM-dd-yyyy";
            this.dtpImpDate.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpImpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpImpDate.Location = new System.Drawing.Point(54, 138);
            this.dtpImpDate.Name = "dtpImpDate";
            this.dtpImpDate.Size = new System.Drawing.Size(144, 33);
            this.dtpImpDate.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 63;
            this.label2.Text = "កាលបរិច្ឆេទ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Sans Khmer", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(222, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 43);
            this.label7.TabIndex = 62;
            this.label7.Text = "ព័ត៌មានការបញ្ជាទិញ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Noto Sans Khmer", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(322, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 25);
            this.label12.TabIndex = 90;
            this.label12.Text = "ព័ត៌មានផលិតផល";
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(710, 716);
            this.ControlBox = false;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lsvImpDetail);
            this.Controls.Add(this.txtCusName);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtInStockPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCusID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStaffID);
            this.Controls.Add(this.dtpImpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailForm";
            this.Text = "OrderDetailForm";
            this.Load += new System.EventHandler(this.OrderDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lsvImpDetail;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInStockPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCusID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStaffID;
        private System.Windows.Forms.DateTimePicker dtpImpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
    }
}