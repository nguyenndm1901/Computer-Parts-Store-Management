using CPSM_DAL;
using CPSM_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CPSM_BUS
{
    public class DanhSachSanPham_BUS
    {
        private DanhSachSanPham_DAL dsspDal;

        public DanhSachSanPham_BUS()
        {
            dsspDal = new DanhSachSanPham_DAL();
        }

        public bool them(DanhSachSanPham_DTO dssp)
        {
            bool re = dsspDal.them(dssp);
            return re;
        }

        public bool xoa(DanhSachSanPham_DTO dssp)
        {
            bool re = dsspDal.xoa(dssp);
            return re;
        }

        public bool sua(DanhSachSanPham_DTO dssp)
        {
            bool re = dsspDal.sua(dssp);
            return re;
        }

        public List<DanhSachSanPham_DTO> select()
        {
            return dsspDal.select();
        }
        public List<DanhSachSanPham_DTO> selectNameByKeyWord(string sKeyword)
        {
            return dsspDal.selectNameByKeyWord(sKeyword);
        }
    }
}
