using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace apiframework.Controllers
{
    [ApiController]
    [Route("makan")]
    public class ConnectionController : Controller
    {
        private readonly koneksi _koneksi;
        public ConnectionController(koneksi koneksi)
        { 
            _koneksi = koneksi;
        }

        [HttpGet("test")]
        public IActionResult GetAll()
        {
            var list = new List<object>();
            using (SqlConnection conn = _koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kategori", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new

                    {

                        Id = reader["Id"],

                        NamaKategori = reader["NamaKategori"]

                    });
                }
                reader.Close();
            }
            return Ok(list);
        }
    }
}
