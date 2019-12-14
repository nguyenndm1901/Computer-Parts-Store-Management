using CPSM_DTO;
using CPSM_BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ComputerPartsStoreManagement
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void đóngỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showtc()
        {
            frmMain tc = new frmMain();
            tc.ShowDialog();
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showtc));
            thread.Start();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private KhachHang_BUS khBus;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;
            KhachHang_DTO kh = new KhachHang_DTO();

            bool kq = khBus.search(kh);
            if (kq == false)
                MessageBox.Show("Tra cứu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Tra cứu thành công");
                this.loadData_Vao_GridView();
            }
        }

        private void loadData_Vao_GridView()
        {
            List<KhachHang_DTO> listKhachHang = khBus.selectByKeyWord(txtTenKH.Text);

            if (listKhachHang == null)
            {
                MessageBox.Show("Có lỗi khi lấy thông tin khách hàng từ DataBase");
                return;
            }

            dgvSearch.Columns.Clear();
            dgvSearch.DataSource = null;

            dgvSearch.AutoGenerateColumns = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.DataSource = listKhachHang;

            DataGridViewTextBoxColumn clNgayMua = new DataGridViewTextBoxColumn();
            clNgayMua.Name = "ngayMua";
            clNgayMua.HeaderText = "Ngày Mua Hàng";
            clNgayMua.DataPropertyName = "ngayMua";
            dgvSearch.Columns.Add(clNgayMua);

            DataGridViewTextBoxColumn clMaHD = new DataGridViewTextBoxColumn();
            clMaHD.Name = "maHD";
            clMaHD.HeaderText = "Mã Hóa Đơn";
            clMaHD.DataPropertyName = "maHD";
            dgvSearch.Columns.Add(clMaHD);

            DataGridViewTextBoxColumn clTenKH = new DataGridViewTextBoxColumn();
            clTenKH.Name = "tenKH";
            clTenKH.HeaderText = "Tên Khách Hàng";
            clTenKH.DataPropertyName = "tenKH";
            dgvSearch.Columns.Add(clTenKH);

            DataGridViewTextBoxColumn clSDT = new DataGridViewTextBoxColumn();
            clSDT.Name = "sdt";
            clSDT.HeaderText = "Số Điện Thoại";
            clSDT.DataPropertyName = "sdt";
            dgvSearch.Columns.Add(clSDT);            

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvSearch.DataSource];
            myCurrencyManager.Refresh();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            khBus = new KhachHang_BUS();
        }
    }
}
