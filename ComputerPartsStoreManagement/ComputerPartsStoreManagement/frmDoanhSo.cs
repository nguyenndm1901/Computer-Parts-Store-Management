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
    public partial class frmDoanhSo : Form
    {
        public frmDoanhSo()
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

        private void frmDoanhSo_Load(object sender, EventArgs e)
        {
            LoadDataLenDGV();
        }
        private void LoadDataLenDGV()
        {
            dgvDoanhSo.DataSource = GetAllDoanhSo();
        }

        private DataTable GetAllDoanhSo()
        {
            DataTable dtDoanhSo = new DataTable();
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [maNV] as [Mã Nhân Viên],[tenNV] as [Tên Nhân Viên],[doanhThu] as [Doanh Số] FROM [NhanVien]", cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtDoanhSo.Load(reader);
                }
            }

            return dtDoanhSo;
        }
    }
}
