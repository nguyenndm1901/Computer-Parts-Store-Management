namespace ComputerPartsStoreManagement
{
    partial class frmSuaXoaSanPham
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.txtBH = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblBH = new System.Windows.Forms.Label();
            this.lblDVT = new System.Windows.Forms.Label();
            this.lblGiaTien = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.btnOKEdit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngỨngDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOKDelete = new System.Windows.Forms.Button();
            this.gbAdd.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(590, 75);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(151, 69);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa Sản Phẩm";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(590, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 69);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa Sản Phẩm";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.txtBH);
            this.gbAdd.Controls.Add(this.txtDVT);
            this.gbAdd.Controls.Add(this.txtGia);
            this.gbAdd.Controls.Add(this.txtTenSP);
            this.gbAdd.Controls.Add(this.txtMaSP);
            this.gbAdd.Controls.Add(this.lblBH);
            this.gbAdd.Controls.Add(this.lblDVT);
            this.gbAdd.Controls.Add(this.lblGiaTien);
            this.gbAdd.Controls.Add(this.lblTenSP);
            this.gbAdd.Controls.Add(this.lblMaSP);
            this.gbAdd.Enabled = false;
            this.gbAdd.Location = new System.Drawing.Point(12, 59);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(572, 167);
            this.gbAdd.TabIndex = 4;
            this.gbAdd.TabStop = false;
            // 
            // txtBH
            // 
            this.txtBH.Location = new System.Drawing.Point(124, 121);
            this.txtBH.Name = "txtBH";
            this.txtBH.Size = new System.Drawing.Size(94, 20);
            this.txtBH.TabIndex = 10;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(342, 81);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(94, 20);
            this.txtDVT.TabIndex = 9;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(124, 81);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(94, 20);
            this.txtGia.TabIndex = 8;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(342, 41);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(224, 20);
            this.txtTenSP.TabIndex = 7;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(124, 41);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(94, 20);
            this.txtMaSP.TabIndex = 6;
            // 
            // lblBH
            // 
            this.lblBH.Location = new System.Drawing.Point(6, 110);
            this.lblBH.Name = "lblBH";
            this.lblBH.Size = new System.Drawing.Size(112, 40);
            this.lblBH.TabIndex = 4;
            this.lblBH.Text = "Thời gian bảo hành:";
            this.lblBH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDVT
            // 
            this.lblDVT.Location = new System.Drawing.Point(224, 70);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(112, 40);
            this.lblDVT.TabIndex = 3;
            this.lblDVT.Text = "Đơn vị tính:";
            this.lblDVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGiaTien
            // 
            this.lblGiaTien.Location = new System.Drawing.Point(6, 70);
            this.lblGiaTien.Name = "lblGiaTien";
            this.lblGiaTien.Size = new System.Drawing.Size(112, 40);
            this.lblGiaTien.TabIndex = 2;
            this.lblGiaTien.Text = "Giá Tiền:";
            this.lblGiaTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenSP
            // 
            this.lblTenSP.Location = new System.Drawing.Point(224, 30);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(112, 40);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Tên sản phẩm:";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaSP
            // 
            this.lblMaSP.Location = new System.Drawing.Point(6, 30);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(112, 40);
            this.lblMaSP.TabIndex = 0;
            this.lblMaSP.Text = "Mã sản phẩm:";
            this.lblMaSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOKEdit
            // 
            this.btnOKEdit.Enabled = false;
            this.btnOKEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKEdit.Location = new System.Drawing.Point(12, 235);
            this.btnOKEdit.Name = "btnOKEdit";
            this.btnOKEdit.Size = new System.Drawing.Size(91, 30);
            this.btnOKEdit.TabIndex = 7;
            this.btnOKEdit.Text = "Sửa";
            this.btnOKEdit.UseVisualStyleBackColor = true;
            this.btnOKEdit.Click += new System.EventHandler(this.btnOKEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.đóngỨngDụngToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            this.trangChủToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // đóngỨngDụngToolStripMenuItem
            // 
            this.đóngỨngDụngToolStripMenuItem.Name = "đóngỨngDụngToolStripMenuItem";
            this.đóngỨngDụngToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.đóngỨngDụngToolStripMenuItem.Text = "Đóng ứng dụng";
            this.đóngỨngDụngToolStripMenuItem.Click += new System.EventHandler(this.đóngỨngDụngToolStripMenuItem_Click);
            // 
            // btnOKDelete
            // 
            this.btnOKDelete.Enabled = false;
            this.btnOKDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKDelete.Location = new System.Drawing.Point(136, 235);
            this.btnOKDelete.Name = "btnOKDelete";
            this.btnOKDelete.Size = new System.Drawing.Size(91, 30);
            this.btnOKDelete.TabIndex = 9;
            this.btnOKDelete.Text = "Xóa";
            this.btnOKDelete.UseVisualStyleBackColor = true;
            this.btnOKDelete.Click += new System.EventHandler(this.btnOKDelete_Click);
            // 
            // frmSuaXoaSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 286);
            this.Controls.Add(this.btnOKDelete);
            this.Controls.Add(this.btnOKEdit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSuaXoaSanPham";
            this.Text = "Sửa, Xóa Sản Phẩm";
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.TextBox txtBH;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblBH;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.Label lblGiaTien;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Button btnOKEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngỨngDụngToolStripMenuItem;
        private System.Windows.Forms.Button btnOKDelete;
    }
}