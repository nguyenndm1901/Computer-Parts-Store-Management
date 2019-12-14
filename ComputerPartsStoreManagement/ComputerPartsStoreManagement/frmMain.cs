using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerPartsStoreManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void đóngỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showtsp()
        {
            frmThemSanPham tsp = new frmThemSanPham();
            tsp.ShowDialog();
        }
        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showtsp));
            thread.Start();
            this.Close();
        }

        private void showlhd()
        {
            frmLapHoaDon hd = new frmLapHoaDon();
            hd.ShowDialog();
        }
        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showlhd));
            thread.Start();
            this.Close();
        }

        private void showkh()
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }
        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showkh));
            thread.Start();
            this.Close();
        }

        
        

        private void showdt()
        {
            frmDoanhThu dt = new frmDoanhThu();
            dt.ShowDialog();
        }
        private void doanhThuCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showdt));
            thread.Start();
            this.Close();
        }

        private void showds()
        {
            frmDoanhSo ds = new frmDoanhSo();
            ds.ShowDialog();
        }
        private void doanhSốNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showds));
            thread.Start();
            this.Close();
        }

        private void showhd()
        {
            frmHoaDon hd = new frmHoaDon();
            hd.ShowDialog();
        }
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showhd));
            thread.Start();
            this.Close();
        }

        private void showsold()
        {
            frmSanPhamDaBan hd = new frmSanPhamDaBan();
            hd.ShowDialog();
        }
        private void sảnPhẩmĐãBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showsold));
            thread.Start();
            this.Close();
        }

        private void sửaXóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showedit));
            thread.Start();
            this.Close();
        }

        private void showedit()
        {
            frmSuaXoaSanPham edit = new frmSuaXoaSanPham();
            edit.ShowDialog();
        }
    }
}
