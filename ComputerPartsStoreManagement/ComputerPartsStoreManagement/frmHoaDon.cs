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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
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

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataLenDGV();
        }

        private void LoadDataLenDGV()
        {
            dgvHoaDon.DataSource = GetAllHoaDon();
        }

        private DataTable GetAllHoaDon()
        {
            DataTable dtHoaDon = new DataTable();
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [maHD] as [Mã Hóa Đơn],[ngayXuatHD] as [Ngày Xuất Hóa Đơn],[tenKH] as [Tên Khách Hàng],[tenNV] as [Tên Nhân Viên],[tongTien] as [Tổng Tiền] FROM [HoaDon]", cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtHoaDon.Load(reader);
                }
            }

            return dtHoaDon;
        }
    }
}
