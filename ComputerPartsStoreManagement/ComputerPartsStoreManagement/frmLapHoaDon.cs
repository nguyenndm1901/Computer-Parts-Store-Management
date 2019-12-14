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
using ComputerPartsStoreManagement.Properties;

namespace ComputerPartsStoreManagement
{
    public partial class frmLapHoaDon : Form
    {
        public frmLapHoaDon()
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

        private List<HoaDon_DTO> HoaDon = new List<HoaDon_DTO>();
        public enum Save
        {
            save = 1,
        }
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                bool hasSameSanPham = false;
                foreach (DataGridViewRow row in dgvHD.Rows)
                {
                    if (Convert.ToInt16(row.Cells["maSP"].Value) == Convert.ToInt16(cbTenSP.SelectedValue))
                    {
                        row.Cells["soLuong"].Value = Convert.ToInt32(row.Cells["soLuong"].Value) + Convert.ToInt32(txtSoLuong.Text);
                        row.Cells["tongCong"].Value = Convert.ToInt32(row.Cells["soLuong"].Value) * Convert.ToInt32(row.Cells["giaTien"].Value);
                        hasSameSanPham = true;
                    }
                }

                if (hasSameSanPham == false)
                {
                    HoaDon_DTO hd = new HoaDon_DTO()
                    {
                        maSP = Convert.ToString(cbTenSP.SelectedValue),
                        tenSP = cbTenSP.Text,
                        dvt = txtDVT.Text,
                        soLuong = Convert.ToInt32(txtSoLuong.Text.Trim()),
                        giaTien = Convert.ToInt32(txtDonGia.Text.Trim()),
                        baoHanh = Convert.ToInt32(txtBaoHanh.Text.Trim()),
                        tongCong = Convert.ToInt32(txtSoLuong.Text.Trim()) * Convert.ToInt32(txtDonGia.Text.Trim())
                    };
                    HoaDon.Add(hd);

                    dgvHD.DataSource = null;
                    dgvHD.DataSource = HoaDon;
                }
                dgvHD.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvHD.Columns[1].HeaderText = "Tên Sản Phẩm";
                dgvHD.Columns[2].HeaderText = "Đơn Vị Tính";
                dgvHD.Columns[3].HeaderText = "Số Lượng";
                dgvHD.Columns[4].HeaderText = "Đơn Giá";
                dgvHD.Columns[5].HeaderText = "Bảo Hành (tháng)";
                dgvHD.Columns[6].HeaderText = "Thành Tiền";

                decimal total = HoaDon.Sum(x => x.tongCong);
                txtTotal.Text = total.ToString();

                cbTenSP.SelectedIndex = -1;
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtDVT.Clear();
                cbTenNV.Enabled = false;
            }
        }

        private bool IsValidated()
        {
            if (txtMaHoaDon.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHoaDon.Focus();
                return false;
            }
            if (txtTenKH.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
                return false;
            }
            if (txtSDT.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            if (cbTenNV.SelectedIndex == -1)
            {
                MessageBox.Show("Yêu cầu chọn mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbTenSP.SelectedIndex == -1)
            {
                MessageBox.Show("Yêu cầu chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSoLuong.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                int tempSoLuong;
                bool isNumberic = int.TryParse(txtSoLuong.Text.Trim(), out tempSoLuong);
                if (!isNumberic)
                {
                    MessageBox.Show("Số lượng phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                    return false;
                }
            }
            if (txtDVT.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Yêu cầu chọn đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string maHD;
            bool isMaHoaDonExisted = true;
            while (isMaHoaDonExisted)
            {
                maHD = GenerateMaHoaDon();
                isMaHoaDonExisted = check(maHD);
                txtMaHoaDon.Text = maHD;
            }
            btnNew.Enabled = false;
            btnPrint.Enabled = true;
            btnPreview.Enabled = true;
            ItemGroupBox.Enabled = true;
            txtTenKH.Focus();
        }

        private bool check(string maHD)
        {
            bool MaHoaDonExist = false;
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            int tongcong = Convert.ToInt32(txtTotal.Text);
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon WHERE [maHD] = @maHD", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    cmd.Parameters.AddWithValue("@tongTien", tongcong);
                    DataTable dtAnyData = new DataTable();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtAnyData.Load(reader);
                    if (dtAnyData.Rows.Count > 0)
                    {
                        MaHoaDonExist = true;
                    }
                }
            }
            return MaHoaDonExist;
        }

        private string GenerateMaHoaDon()
        {
            string maHD;
            Random ran = new Random();
            long orderpart1 = ran.Next(100, 999);
            int orderpart2 = ran.Next(0, 99);
            maHD = orderpart1 + "-" + orderpart2;
            return maHD;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dgvHD.CurrentCell.RowIndex;
            HoaDon.RemoveAt(index);
            dgvHD.DataSource = null;
            dgvHD.DataSource = HoaDon;
            decimal total = HoaDon.Sum(x => x.tongCong);
            txtTotal.Text = total.ToString();
        }

        private void DgvHD_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hit = dgvHD.HitTest(e.X, e.Y);
                dgvHD.Rows[hit.RowIndex].Selected = true;
                contextMenuStrip1.Show(dgvHD, e.X, e.Y);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.banner;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("# Mã Hóa Đơn: " + txtMaHoaDon.Text.Trim(), new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(25, 145));
            e.Graphics.DrawString("Ngày tạo: " + DateTime.Now, new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(25, 175));
            e.Graphics.DrawString("Tên khách hàng: " + txtTenKH.Text.Trim(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, 205));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, 325));
            e.Graphics.DrawString("Số điện thoại: " + txtSDT.Text.Trim(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, 235));
            e.Graphics.DrawString("Tên nhân viên: " + cbTenNV.Text.Trim(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, 265));
            e.Graphics.DrawString("Sản phẩm", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(30, 355));
            e.Graphics.DrawString("ĐVT", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(360, 355));
            e.Graphics.DrawString("SL", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(305, 355));
            e.Graphics.DrawString("Đơn giá", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(425, 355));
            e.Graphics.DrawString("BH (tháng)", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(520, 355));
            e.Graphics.DrawString("Thành tiền", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(650, 355));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, 385));

            int yPos = 415;
            for (int i = numberOfItemsPrintedSoFar; i < HoaDon.Count; i++)
            {
                numberOfItemsPerPage++;
                if (numberOfItemsPerPage <= 25)
                {
                    numberOfItemsPrintedSoFar++;
                    if (numberOfItemsPrintedSoFar <= HoaDon.Count)
                    {
                        e.Graphics.DrawString(HoaDon[i].tenSP, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                        e.Graphics.DrawString(HoaDon[i].dvt, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(367, yPos));
                        e.Graphics.DrawString(HoaDon[i].soLuong.ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(308, yPos));
                        e.Graphics.DrawString(HoaDon[i].baoHanh.ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(550, yPos));
                        e.Graphics.DrawString(HoaDon[i].giaTien.ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(429, yPos));
                        e.Graphics.DrawString(HoaDon[i].tongCong.ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(653, yPos));
                        yPos += 30;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, yPos));
            e.Graphics.DrawString("Tổng Cộng", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(25, yPos + 30));
            e.Graphics.DrawString(txtTotal.Text.Trim() + " vnđ", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(625, yPos + 30));

            //reset giá trị
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {
            cbTenSP.SelectedValueChanged -= cbTenSP_SelectedValueChanged;
            cbTenSP.DataSource = GettenSP();
            cbTenSP.DisplayMember = "tenSP";
            cbTenSP.ValueMember = "id";
            cbTenSP.SelectedIndex = -1;
            cbTenSP.SelectedValueChanged += cbTenSP_SelectedValueChanged;

            cbTenNV.DataSource = GettenNV();
            cbTenNV.DisplayMember = "tenNV";
            cbTenNV.ValueMember = "id";
            cbTenNV.SelectedIndex = -1;
        }

        private DataTable GettenNV()
        {
            DataTable dtNhanVien = new DataTable();
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, tenNV FROM NhanVien", cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtNhanVien.Load(reader);
                }
            }
            return dtNhanVien;
        }

        private DataTable GettenSP()
        {
            DataTable dtSanPham = new DataTable();
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, tenSP FROM SanPham", cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtSanPham.Load(reader);
                }
            }
            return dtSanPham;
        }

        private void cbTenSP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTenSP.SelectedValue != null)
            {
                int id = Convert.ToInt16(cbTenSP.SelectedValue);
                int giaTien = GetgiaTien(id);
                txtDonGia.Text = giaTien.ToString();
                string donVi = GetdonVi(id);
                txtDVT.Text = donVi.ToString();
                int baohanh = GetbaoHanh(id);
                txtBaoHanh.Text = baohanh.ToString();

            }
        }

        private int GetgiaTien(int id)
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT giaTien FROM SanPham WHERE id=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private string GetdonVi(int id)
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT dvt FROM SanPham WHERE id=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    return (string)cmd.ExecuteScalar();
                }
            }
        }

        private int GetbaoHanh(int id)
        {
            string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT thoiGianBH FROM SanPham WHERE id=@id", cnn))
                {
                    cnn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LuuHoaDon((int)Save.save);
            btnNew.Enabled = true;
            btnPrint.Enabled = false;
            btnPreview.Enabled = false;
            ItemGroupBox.Enabled = false;
            cbTenNV.Enabled = true;

            txtMaHoaDon.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            cbTenNV.SelectedItem = -1;
            cbTenSP.SelectedItem = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtMaHoaDon.Clear();
            dgvHD.Focus();
            txtTotal.Text = "0";
            dgvHD.DataSource = null;
        }

        private void LuuHoaDon(int luu)
        {
            try
            {
                string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [HoaDon](maHD,ngayXuatHD,tongTien,tenKH,tenNV) VALUES (@maHD,@ngayXuatHD,@tongTien,@tenKH,@tenNV)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@maHD", txtMaHoaDon.Text);
                        cmd.Parameters.AddWithValue("@ngayXuatHD", dateNgayTao.Value.Date);
                        cmd.Parameters.AddWithValue("@tongTien", txtTotal.Text);
                        cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@tenNV", cbTenNV.Text);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [KhachHang](ngayMua,maHD,tenKH,sdt) VALUES (@ngayMua,@maHD,@tenKH,@sdt)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@ngayMua", dateNgayTao.Value.Date);
                        cmd.Parameters.AddWithValue("@maHD", txtMaHoaDon.Text);
                        cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                        cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE NhanVien SET doanhThu = doanhThu + @update WHERE tenNV = @tenNV", cnn))
                    {
                        cmd.Parameters.AddWithValue("@update", Convert.ToInt32(txtTotal.Text.Trim()));
                        cmd.Parameters.AddWithValue("@tenNV", cbTenNV.Text);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (DataGridViewRow row in dgvHD.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [ThongKe](ngay,maHD,maSP,tenSP,dvt,soLuong,giaTien,thanhTien) VALUES (@ngay,@maHD,@maSP,@tenSP,@dvt,@soLuong,@giaTien,@thanhTien)", cnn))
                        {
                            cmd.Parameters.AddWithValue("@ngay", dateNgayTao.Value.Date);
                            cmd.Parameters.AddWithValue("@maHD", txtMaHoaDon.Text);
                            cmd.Parameters.AddWithValue("@maSP", Convert.ToString(row.Cells["maSP"].Value));
                            cmd.Parameters.AddWithValue("@tenSP", Convert.ToString(row.Cells["tenSP"].Value));
                            cmd.Parameters.AddWithValue("@dvt", Convert.ToString(row.Cells["dvt"].Value));
                            cmd.Parameters.AddWithValue("@soLuong", Convert.ToInt16(row.Cells["soLuong"].Value));
                            cmd.Parameters.AddWithValue("@giaTien", Convert.ToInt32(row.Cells["giaTien"].Value));
                            cmd.Parameters.AddWithValue("@thanhTien", Convert.ToInt32(row.Cells["tongCong"].Value));

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Đã in hóa đơn", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
