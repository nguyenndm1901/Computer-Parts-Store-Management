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
    public class DanhSachSanPham_DAL
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public bool them(DanhSachSanPham_DTO dssp)
        {
            string query = string.Empty;
            query += "INSERT INTO [DanhSachSanPham] ([maSP], [tenSP], [giaTien], [dvt], [thoiGianBH], [soLuong])";
            query += "VALUES (@maSP, @tenSP,@giaTien, @dvt, @thoiGianBH, @soLuong)";
            using (SqlConnection _cnn = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _cnn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maSP", dssp.maSP);
                    cmd.Parameters.AddWithValue("@tenSP", dssp.tenSP);
                    cmd.Parameters.AddWithValue("@giaTien", dssp.giaTien);
                    cmd.Parameters.AddWithValue("@dvt", dssp.dvt);
                    cmd.Parameters.AddWithValue("@thoiGianBH", dssp.thoiGianBH);
                    cmd.Parameters.AddWithValue("@soLuong", dssp.soLuong);
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
        public bool xoa(DanhSachSanPham_DTO dssp)
        {
            string query = string.Empty;
            query += "DELETE FROM [DanhSachSanPham] WHERE [maSP] = @maSP";
            using (SqlConnection _cnn = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _cnn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maSP", dssp.maSP);
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
        public bool sua(DanhSachSanPham_DTO dssp)
        {
            string query = string.Empty;
            query += "UPDATE [DanhSachSanPham] SET [tenSP] = @tenSP, [giaTien] = @giaTien, [dvt] = @dvt, [thoiGianBH] = @thoiGianBH, [soLuong] = @soLuong WHERE [maSP] = @maSP";
            using (SqlConnection _cnn = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _cnn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maSP", dssp.maSP);
                    cmd.Parameters.AddWithValue("@tenSP", dssp.tenSP);
                    cmd.Parameters.AddWithValue("@giaTien", dssp.giaTien);
                    cmd.Parameters.AddWithValue("@dvt", dssp.dvt);
                    cmd.Parameters.AddWithValue("@thoiGianBH", dssp.thoiGianBH);
                    cmd.Parameters.AddWithValue("@soLuong", dssp.soLuong);
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

        public List<DanhSachSanPham_DTO> select()
        {
            string query = string.Empty;
            query += "SELECT [maSP], [tenSP], [giaTien], [dvt], [thoiGianBH], [soLuong]";
            query += "FROM [DanhSachSanPham]";

            List<DanhSachSanPham_DTO> lsSanPham = new List<DanhSachSanPham_DTO>();

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
                                DanhSachSanPham_DTO sp = new DanhSachSanPham_DTO();
                                sp.maSP = reader["maSP"].ToString();
                                sp.tenSP = reader["tenSP"].ToString();
                                sp.giaTien = Convert.ToInt32(reader["giaTien"].ToString());
                                sp.dvt = reader["dvt"].ToString();
                                sp.thoiGianBH = Convert.ToInt32(reader["thoiGianBH"].ToString());
                                sp.soLuong = Convert.ToInt32(reader["soLuong"].ToString());
                                lsSanPham.Add(sp);
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
            return lsSanPham;
        }

        public List<DanhSachSanPham_DTO> selectNameByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += "SELECT * FROM [DanhSachSanPham]";
            query += " WHERE ([sp_hoten] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " WHERE ([sp_ngaykham] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_masp] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_hoten] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_gioitinh] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_namsinh] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_sdt] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_loaibenh] LIKE CONCAT('%',@sKeyword,'%'))";
            //query += " OR ([sp_trieuchung] LIKE CONCAT('%',@sKeyword,'%'))";

            List<DanhSachSanPham_DTO> lsSanPham = new List<DanhSachSanPham_DTO>();

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
                                DanhSachSanPham_DTO sp = new DanhSachSanPham_DTO();
                                sp.maSP = reader["maSP"].ToString();
                                sp.tenSP = reader["tenSP"].ToString();
                                sp.giaTien = Convert.ToInt32(reader["giaTien"].ToString());
                                sp.dvt = reader["dvt"].ToString();
                                sp.thoiGianBH = Convert.ToInt32(reader["thoiGianBH"].ToString());
                                sp.soLuong = Convert.ToInt32(reader["soLuong"].ToString());
                                lsSanPham.Add(sp);
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
            return lsSanPham;
        }
    }
}

