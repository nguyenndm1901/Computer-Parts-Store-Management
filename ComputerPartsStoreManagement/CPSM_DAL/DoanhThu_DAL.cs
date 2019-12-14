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
    public class DoanhThu_DAL
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public bool search(DoanhThu_DTO dt)
        {
            string query = string.Empty;
            query += "SELECT [maHD], [ngayXuatHD], [tongTien], [tenKH], [tenNV] FROM HoaDon";
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
        public List<DoanhThu_DTO> select()
        {
            string query = string.Empty;
            query += "SELECT [maHD], [ngayXuatHD], [tongTien], [tenKH], [tenNV] FROM HoaDon";

            List<DoanhThu_DTO> lsDoanhThu = new List<DoanhThu_DTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DoanhThu_DTO dt = new DoanhThu_DTO();
                                dt.maHD = reader["maHD"].ToString();
                                dt.ngayXuatHD = reader["ngayXuatHD"].ToString();
                                dt.tongTien = Convert.ToInt32(reader["tongTien"].ToString());
                                dt.tenKH = reader["tenKH"].ToString();
                                dt.tenNV = reader["tenNV"].ToString();
                                lsDoanhThu.Add(dt);
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
            return lsDoanhThu;
        }        
    }
}
