using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace apiframework.Controllers
{
    public class KategoriController : Controller
    {
        private readonly koneksi _koneksi;
        public KategoriController(koneksi koneksi)
        {
            _koneksi = koneksi;
        }

        [HttpGet("id")]
        public object GetSigleKategori(int id)
        {
            var result = new
            {
                Status = 200,
                Data = new
                {
                    id = 0,
                    Nama = ""
                }
            };

            SqlConnection conn = _koneksi.GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kategori WHERE id=" + id, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) 
                {
                    result = new
                    {
                        Status = 200,
                        Data = new
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Nama = reader["NamaKategori"].ToString()
                        }
                    };
                }
                return result;
            }
            catch (Exception e)
            {
                return new
                {
                    Status = 500,
                    Message = e.Message
                };
                
            }

        }
    }
}
