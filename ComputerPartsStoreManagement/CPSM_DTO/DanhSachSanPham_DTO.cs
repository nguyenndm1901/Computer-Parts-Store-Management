using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSM_DTO
{
    public class DanhSachSanPham_DTO
    {
        protected string _masp;
        public string maSP { get => _masp; set => _masp = value; }

        protected string _tensp;
        public string tenSP { get => _tensp; set => _tensp = value; }

        protected int _giatien;
        public int giaTien { get => _giatien; set => _giatien = value; }

        protected string _dvt;
        public string dvt { get => _dvt; set => _dvt = value; }

        protected int _thoigianbh;
        public int thoiGianBH { get => _thoigianbh; set => _thoigianbh = value; }

        protected int _soluong;
        public int soLuong { get => _soluong; set => _soluong = value; }
    }
}
