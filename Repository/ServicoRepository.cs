using Dapper;
using SalaoDeBeleza.Model;
using SalaoDeBeleza.Model.Data;

namespace SalaoDeBeleza.Repository
{
    public class ServicoRepository : GenericRepository, IServicoRepository
    {
        private readonly AppDbContext _context;
        private const string TABLE_NAME = "Servico";
        public ServicoRepository(AppDbContext context) : base(context, TABLE_NAME)
        {
            _context = context;
        }
        public async Task<string> Create(Servico nome)
        {
            nome.Id = await Task.Run(() => ObterProximo());
            string response = string.Empty;
            string query = "INSERT INTO Servico (Id, Nome, ClienteId, ValorDefinido, DataAgendada, StatusId, DataCadastro) " +
                           "VALUES (@Id, @Nome, @ClienteId, @ValorDefinido, @DataAgendada, @StatusId, GETDATE())";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    Id = nome.Id,
                    Nome = nome.Nome,
                    ValorDefinido = nome.ValorDefinido,
                    DataAgendada = nome.DataAgendada,
                    StatusId = nome.StatusId,
                    ClienteId = nome.ClienteId,
                });

                response = "pass";
            }

            return response;
        }

        public async Task<List<Servico>> GetAll()
        {
            string query = "SELECT FORMAT(S.DataCadastro, 'dd/MM/yyyy') AS DataCadastro, " +
                " FORMAT(S.DataAgendada, 'dd/MM/yyyy') AS DataAgendada, M.NomeStatus AS NomeStatus, " +
                "C.Cliente, S.ValorDefinido, S.Nome AS NomeServico " +
                "FROM Servico S " +
                "INNER JOIN Manutencao M ON M.Id = S.StatusId " +
                "INNER JOIN Colaborador C ON C.Id = S.ClienteId";

            using(var connection = this._context.CreateConnection())
            {
            var servico = await connection.QueryAsync<Servico>(query);
            return servico.ToList();
            }
        }

        public async Task<Servico> GetbyId(int id)
        {
            string query = "SELECT * FROM Servico where id = @Id";

            using (var connection = this._context.CreateConnection())
            {
                var servico = await connection.QueryFirstOrDefaultAsync<Servico>(query, new {id});
                return servico;
            }
        }

        public async Task<List<Servico>> GetByTipo(int Nome)
        {
            string query = "SELECT * FROM Servico WHERE statusId = @statusId";

            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Servico>(query, new { statusId = Nome });
                return emplist.ToList();
            }
        }

        public async Task<string> Remove(int Id)
        {
            string response = string.Empty;
            string query = "Delete From Servico where Id = @Id";
            using (var connectin = this._context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, new { Id });
                response = "pass";
            }
            return response;
        }

        public async Task<string> Update(Servico nome, int Id)
        {
            string response = string.Empty;
            string query = "UPDATE Servico " +
                    "SET Nome = @Nome, " +
                    "ValorDefinido = @ValorDefinido, " +
                    "DataAgendada = @DataAgendada, " +
                    "StatusId = @StatusId, ClienteId = @ClienteId " +
                    "WHERE Id = @id";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    id = nome.Id,
                    ClienteId = nome.ClienteId,
                    Nome = nome.Nome,
                    ValorDefinido = nome.ValorDefinido,
                    DataAgendada = nome.DataAgendada,
                    StatusId = nome.StatusId,
                });

                response = "pass";
            }
            return response;
        }
    }
}
