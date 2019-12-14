using CPSM_DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSM_DAL
{
    public class KhachHang_DAL
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public bool search(KhachHang_DTO kh)
        {
            string query = string.Empty;
            query += "SELECT [ngayMua], [maHD], [tenKH], [sdt] FROM KhachHang";
            using (SqlConnection _cnn = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _cnn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    try
                    {
                        _cnn.Open();
                        cmd.ExecuteNonQuery();
                        _cnn.Close();
                        _cnn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        _cnn.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        //public List<KhachHang_DTO> select()
        //{
        //    string query = string.Empty;
        //    query += "SELECT [ngayMua], [maHD], [tenKH], [sdt] FROM KhachHang";

        //    List<KhachHang_DTO> lsKhachHang = new List<KhachHang_DTO>();

        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = con;
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = query;

        //            try
        //            {
        //                con.Open();
        //                SqlDataReader reader = null;
        //                reader = cmd.ExecuteReader();
        //                if (reader.HasRows == true)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        KhachHang_DTO kh = new KhachHang_DTO();
        //                        kh.ngayMua = reader["ngayMua"].ToString();
        //                        kh.maHD = reader["maHD"].ToString();
        //                        kh.tenKH = reader["tenKH"].ToString();
        //                        kh.sdt = reader["sdt"].ToString();
        //                        lsKhachHang.Add(kh);
        //                    }
        //                }

        //                con.Close();
        //                con.Dispose();
        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                return null;
        //            }
        //        }
        //    }
        //    return lsKhachHang;
        //}
        public List<KhachHang_DTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += "SELECT [ngayMua],[maHD],[tenKH],[sdt] FROM KhachHang";
            query += " WHERE ([tenKH] LIKE CONCAT('%',@sKeyword,'%'))";

            List<KhachHang_DTO> lsKhachHang = new List<KhachHang_DTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                KhachHang_DTO kh = new KhachHang_DTO();
                                kh.ngayMua = reader["ngayMua"].ToString();
                                kh.maHD = reader["MaHD"].ToString();
                                kh.tenKH = reader["tenKH"].ToString();                                
                                kh.sdt = reader["sdt"].ToString();
                                lsKhachHang.Add(kh);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return lsKhachHang;
        }
    }
}
