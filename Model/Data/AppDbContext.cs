using Microsoft.Data.SqlClient;
using System.Data;

namespace SalaoDeBeleza.Model.Data
{
    public class AppDbContext
    {
        private readonly IConfiguration _context;
        private readonly string connectionstring;
        public AppDbContext(IConfiguration context)
        {
            _context = context;
            connectionstring = _context.GetConnectionString("DevConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
