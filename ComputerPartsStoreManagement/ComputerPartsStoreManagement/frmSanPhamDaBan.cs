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
    public partial class frmSanPhamDaBan : Form
    {
        public frmSanPhamDaBan()
        {
            InitializeComponent();
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

        private void đóngỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSanPhamDaBan_Load(object sender, EventArgs e)
        {
            LoadDataLenDGV();
        }

        private void LoadDataLenDGV()
        {
            dgvSold.DataSource = GetAllSold();
        }

        private DataTable GetAllSold()
        {
            DataTable dtSold = new DataTable();
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ngay] as [Ngày Bán],[maHD] as [Mã Hóa Đơn],[maSP] as [Mã Sản Phẩm],[tenSP] as [Tên Sản Phẩm],[dvt] as [Đơn Vị Tính],[soLuong] as [Số Lượng],[giaTien] as [Đơn Giá],[thanhTien] as [Thành Tiền] FROM [ThongKe]", cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtSold.Load(reader);
                }
            }

            return dtSold;
        }
    }
}
