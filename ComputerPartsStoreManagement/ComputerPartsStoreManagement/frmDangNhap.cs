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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private bool isExisted()
        {
            bool tatkt = false;
            string tendangnhap = txtID.Text;
            string matkhau = txtPass.Text;
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from StaffLogIn", con);
            con.Open();
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select id,pass from StaffLogIn where id = '" + tendangnhap + "' and pass = '" + matkhau + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);
            if (dt_kiemtra.Rows.Count <= 0)
            {
                tatkt = true;
            }
            da_kiemtra.Dispose();
            return tatkt;
        }

        private void đóngỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showmain()
        {
            frmMain main = new frmMain();
            main.ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (isExisted())
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ. Kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Clear();
                txtPass.Clear();
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(showmain));
                thread.Start();
                this.Close();
            }
        }

        private void TxtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}