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
    public partial class frmThemSanPham : Form
    {
        public frmThemSanPham()
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            gbAdd.Enabled = true;
            txtMaSP.Focus();
        }

        private bool IsValidated()
        {
            if (txtMaSP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Focus();
                return false;
            }
            if (txtTenSP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSP.Focus();
                return false;
            }
            if (txtDVT.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDVT.Focus();
                return false;
            }
            else
            {
                int tempDVT;
                bool isNumberic = int.TryParse(txtDVT.Text.Trim(), out tempDVT);
                if (isNumberic)
                {
                    MessageBox.Show("Đơn vị tính phải là chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDVT.Clear();
                    txtDVT.Focus();
                    return false;
                }
            }
            if (txtGia.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu giá sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGia.Focus();
                return false;
            }
            else
            {
                int tempGia;
                bool isNumberic = int.TryParse(txtGia.Text.Trim(), out tempGia);
                if (!isNumberic)
                {
                    MessageBox.Show("Giá tiền phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGia.Clear();
                    txtGia.Focus();
                    return false;
                }
            }
            if (txtBH.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu thời gian bảo hành sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBH.Focus();
                return false;
            }
            else
            {
                int tempBH;
                bool isNumberic = int.TryParse(txtBH.Text.Trim(), out tempBH);
                if (!isNumberic)
                {
                    MessageBox.Show("Thời gian bảo hành phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBH.Clear();
                    txtBH.Focus();
                    return false;
                }
            }
            if (isExisted())
            {
                MessageBox.Show("Mã sản phẩm bị trùng. Kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Clear();
                txtMaSP.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                LuuSanPham((int)Save.save);
                btnNew.Enabled = true;
                btnAdd.Enabled = false;
                gbAdd.Enabled = false;

                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGia.Clear();
                txtDVT.Clear();
                txtBH.Clear();
            }
        }

        private bool isExisted()
        {
            bool tatkt = false;
            string maso = txtMaSP.Text;
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from SanPham", con);
            con.Open();
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from SanPham where maSP = '" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);
            if (dt_kiemtra.Rows.Count > 0)
            {
                tatkt = true;
            }
            da_kiemtra.Dispose();
            return tatkt;
        }

        public enum Save
        {
            save = 1,
        }

        private void LuuSanPham(int luu)
        {
            try
            {
                string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [SanPham](maSP,tenSP,giaTien,dvt,thoiGianBH) VALUES (@maSP,@tenSP,@giaTien,@dvt,@thoiGianBH)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@giaTien", txtGia.Text);
                        cmd.Parameters.AddWithValue("@dvt", txtDVT.Text);
                        cmd.Parameters.AddWithValue("@thoiGianBH", txtBH.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Đã lưu sản phẩm", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
