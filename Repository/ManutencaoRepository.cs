using Dapper;
using SalaoDeBeleza.Model;
using SalaoDeBeleza.Model.Data;
using System.Data;

namespace SalaoDeBeleza.Repository
{
    public class ManutencaoRepository : GenericRepository,  IManutencaoRepository
    {
        private readonly AppDbContext _context;
        private const string TABLE_NAME = "Manutencao";
        public ManutencaoRepository(AppDbContext context) : base(context, TABLE_NAME)
        {
            _context = context;
        }

        public async Task<string> Create(Manutencao colaborador)
        {
            colaborador.Id = ObterProximo();
            string response = string.Empty;
            string query = "INSERT INTO Manutencao (Id, NomeStatus, Tipo) " +
                           "VALUES (@Id, @NomeStatus, @Tipo)";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    Id = colaborador.Id,
                    Cliente = colaborador.NomeStatus,
                    Tipo = colaborador.Tipo,
                });

                response = "pass";
            }

            return response;
        }

        public async Task<List<Manutencao>> GetAll()
        {
            string query = "Select * From Manutencao";
            using (var connectin = this._context.CreateConnection())
            {
                var emplist = await connectin.QueryAsync<Manutencao>(query);
                return emplist.ToList();
            }
        }

        public async Task<Manutencao> GetbyId(int Id)
        {
            string query = "Select * From Manutencao where Id = @Id";
            using (var connectin = this._context.CreateConnection())
            {
                var emplist = await connectin.QueryFirstOrDefaultAsync<Manutencao>(query, new { Id });
                return emplist;
            }
        }

        public async Task<int> Remove(int Id)
        {
            int response = 0;
            string query = "Delete From Manutencao where Id = @Id";
            using (var connectin = this._context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, new { Id });

            }
            return response;
        }

        public async Task<string> Update(Manutencao cliente)
        {
            string response = string.Empty;
            string query = "UPDATE Manutencao " +
                    "SET NomeStatus = @NomeStatus, " +
                    "Tipo = @Tipo, " +
                    "WHERE Id = @Id";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    id = cliente.Id,
                    NomeStatus = cliente.NomeStatus,
                    Tipo = cliente.Tipo
                });

                response = "pass";
            }
            return response;
        }

        public async Task<List<Manutencao>> GetByTipo(int tipo)
        {
            string query = "SELECT * FROM Manutencao WHERE tipo = @tipoId";

            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Manutencao>(query, new { tipoId = tipo });
                return emplist.ToList();
            }
        }
        public async Task<List<Manutencao>> GetManutencaoCombo()
        {
            string query = "SELECT Id, NomeStatus FROM Manutencao";
            using (var connectin = this._context.CreateConnection())
            {
                var emplist = await connectin.QueryAsync<Manutencao>(query);
                return emplist.ToList();
            }
        }
    }
}
