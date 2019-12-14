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
    public partial class frmDoanhThu : Form
    {
        private DoanhThu_BUS dtBus;
        public frmDoanhThu()
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

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            dtBus = new DoanhThu_BUS();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = null;
            DoanhThu_DTO dt = new DoanhThu_DTO();

            bool kq = dtBus.search(dt);
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
            List<DoanhThu_DTO> listDoanhThu = dtBus.select();

            if (listDoanhThu == null)
            {
                MessageBox.Show("Có lỗi khi lấy kết quả từ DB");
                return;
            }

            dgvDoanhThu.Columns.Clear();
            dgvDoanhThu.DataSource = null;

            dgvDoanhThu.AutoGenerateColumns = false;
            dgvDoanhThu.AllowUserToAddRows = false;
            dgvDoanhThu.DataSource = listDoanhThu;

            DataGridViewTextBoxColumn clMaHD = new DataGridViewTextBoxColumn();
            clMaHD.Name = "maHD";
            clMaHD.HeaderText = "Mã Hóa Đơn";
            clMaHD.DataPropertyName = "maHD";
            dgvDoanhThu.Columns.Add(clMaHD);

            DataGridViewTextBoxColumn clNgayXuat = new DataGridViewTextBoxColumn();
            clNgayXuat.Name = "ngayXuatHD";
            clNgayXuat.HeaderText = "Ngày Xuất Hóa Đơn";
            clNgayXuat.DataPropertyName = "ngayXuatHD";
            dgvDoanhThu.Columns.Add(clNgayXuat);

            DataGridViewTextBoxColumn clTongTien = new DataGridViewTextBoxColumn();
            clTongTien.Name = "tongTien";
            clTongTien.HeaderText = "Tổng Tiền";
            clTongTien.DataPropertyName = "tongTien";
            dgvDoanhThu.Columns.Add(clTongTien);

            DataGridViewTextBoxColumn cltenKH = new DataGridViewTextBoxColumn();
            cltenKH.Name = "tenKH";
            cltenKH.HeaderText = "Tên Khách Hàng";
            cltenKH.DataPropertyName = "tenKH";
            dgvDoanhThu.Columns.Add(cltenKH);

            DataGridViewTextBoxColumn cltenNV = new DataGridViewTextBoxColumn();
            cltenNV.Name = "tenNV";
            cltenNV.HeaderText = "Tên Nhân Viên";
            cltenNV.DataPropertyName = "tenNV";
            dgvDoanhThu.Columns.Add(cltenNV);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvDoanhThu.DataSource];
            myCurrencyManager.Refresh();

            int total = listDoanhThu.Sum(x => x.tongTien);
            txtTotal.Text = total.ToString();
        }
    }
}
