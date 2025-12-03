using Microsoft.AspNetCore.Mvc;

namespace apiframework.Controllers
{
    [ApiController]
    [Route("api")]
    //[Route("[controller]")]


    public class homecontroller : Controller
    {
        [HttpGet("index")]
        public String Index()
        {
            return "Hallo, welcome to my API!!";
        }

        [HttpGet("sapaan")]
        public String sapaan([FromQuery] string nama = "")
        {
            //return $"Hallo {nama} , welcome to my API
            return "Hallo " + nama + " , welcome to my API!!";
        }

        [HttpGet("{noRumah}")]
        public String noRumah([FromRoute] String noRumah)
        {
            return "Anda tinggal di rumah nomor " + noRumah;
        }

        [HttpGet("simple-User")]
        public object getUser()
        {
            return new
            {
                Id = 1,
                nama = "Bagas S",
                umur = 30,
                alamat = "Jl. Agustus No. 123, Jakarta",
                Role = new String[] {
                    "Admin",
                    "User" },
                PerformanceIndex = new int[]
                {
                    90, 85, 88, 92
                }
            };
        }

        [HttpGet("jsontest/produk-summary")]
        public object getProdukSummary() {
            return new
            {
                jumlahProduk = 10,
                ratarataharga = 15400,
                produktertinggi = new { id = 8, nama = "Kabel HDMI", harga = 75000 },
                produkterendah = new { id = 1, nama = "Penghapus", harga = 1500 },

            };
        }

        [HttpGet("jsontest/produk-grouped")]
        public object getProdukGrup() {

            return new
            {
                elektronik = new object[]
                {
                    new { id = 1, nama = "Keyboard" },
                    new { id = 2, nama = "Mouse" }
                },
                ATK = new object[]
                {
                    new { id = 3, nama = "Buku" },
                    new { id = 4, nama =  "Pulpen" }
                }

            };
        }

        [HttpGet("jsontest/summary")]
        public object getSummary()
        {

            return new
            {
                totalProduk = 12,
                
                produkTermahal = new { id = 4, nama = "Laptop", harga = 8000000 },
                produkTermurah = new { id = 1, nama = "Pensil", harga = 2000 },

                daftarProduk = new object[]
                {
                    new { id = 1, nama = "Pensil" },
                    new { id = 2, nama = "Buku" }
                }

            };
        }
    }
}