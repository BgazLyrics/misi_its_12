using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace apiframework
{
    public class koneksi
    {
        private IConfiguration _configuration;

        public koneksi(IConfiguration configuration)
        {
             _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}
