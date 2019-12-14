using CPSM_DAL;
using CPSM_DTO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSM_BUS
{
    public class KhachHang_BUS {
        private KhachHang_DAL khDal;

        public KhachHang_BUS()
        {
            khDal = new KhachHang_DAL();
        }

        public bool search(KhachHang_DTO dt)
        {
            bool re = khDal.search(dt);
            return re;
        }
        //public List<KhachHang_DTO> select()
        //{
        //    return khDal.select();
        //}
        public List<KhachHang_DTO> selectByKeyWord(string sKeyword)
        {
            return khDal.selectByKeyWord(sKeyword);
        }
    }
}
