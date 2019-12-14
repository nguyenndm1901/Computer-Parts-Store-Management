using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSM_DTO
{
    public class DoanhThu_DTO : HoaDon_DTO
    {
        public string maHD { get; set; }
        public string ngayXuatHD { get; set; }
        public int tongTien { get; set; }
        public string tenKH { get; set; }
        public string tenNV { get; set; }
    }
}
