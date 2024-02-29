using Dapper;
using SalaoDeBeleza.Model.Data;

namespace SalaoDeBeleza.Repository
{
    public abstract class GenericRepository : IGenericRepository
    {
        private readonly AppDbContext _context;
        private readonly string _table;
        public GenericRepository(AppDbContext context, string table)
        {
            _context = context;
            _table = table;
        }
        public int ObterProximo()
        {
            using (var connection = this._context.CreateConnection())
            {
                string sql = $"SELECT MAX(Id) FROM {_table}";
                var maxId = connection.QueryFirstOrDefault<int>(sql);
                return maxId + 1;
            }
        }

    }
}
