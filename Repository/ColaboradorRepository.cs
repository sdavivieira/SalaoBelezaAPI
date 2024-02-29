using Dapper;
using SalaoDeBeleza.Model;
using SalaoDeBeleza.Model.Data;
using System.Data;

namespace SalaoDeBeleza.Repository
{
    public class ColaboradorRepository : GenericRepository, IColaboradorRepository
    {
        private readonly AppDbContext _context;
        private const string TABLE_NAME = "Colaborador";
        public ColaboradorRepository(AppDbContext context) : base(context, TABLE_NAME)
        {
            _context = context;
        }

        public async Task<string> Create(Colaborador colaborador)
        {
            colaborador.Id = await Task.Run(()=>ObterProximo());
            string response = string.Empty;
            string query = "INSERT INTO Colaborador (Id, Cliente, Telefone, Email, DataCadastro) " +
                           "VALUES (@Id, @Cliente, @Telefone, @Email, GETDATE())";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    Id = colaborador.Id,
                    Cliente = colaborador.Cliente,
                    Telefone = colaborador.Telefone,
                    Email = colaborador.Email,
                    DataCadastro = colaborador.DataCadastro,
                });

                response = "pass";
            }

            return response;
        }

        public async Task<List<Colaborador>> GetAll()
        {
            string query = "Select * From Colaborador";
            using (var connectin = this._context.CreateConnection())
            {
                var emplist = await connectin.QueryAsync<Colaborador>(query);
                return emplist.ToList();
            }
        }

        public async Task<Colaborador> GetbyId(int Id)
        {
            string query = "Select * From Colaborador where Id = @Id";
            using (var connectin = this._context.CreateConnection())
            {
                var emplist = await connectin.QueryFirstOrDefaultAsync<Colaborador>(query, new { Id });
                return emplist;
            }
        }

        public async Task<int> Remove(int Id)
        {
            int response = 0;
            string query = "Delete From Colaborador where Id = @Id";
            using (var connectin = this._context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, new { Id });

            }
            return response;
        }

        public async Task<string> Update(Colaborador cliente)
        {
            string response = string.Empty;
            string query = "UPDATE Colaborador " +
                    "SET Cliente = @Cliente, " +
                    "Telefone = @Telefone, " +
                    "Email = @Email " +
                    "WHERE Id = @Id";

            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    id = cliente.Id,
                    Cliente = cliente.Cliente,
                    Telefone = cliente.Telefone,
                    Email = cliente.Email,
                });

                response = "pass";
            }
            return response;
        }

        public async Task<List<Colaborador>> GetByTipo(int tipo)
        {
            string query = "SELECT * FROM Colaborador WHERE tipo = @tipoId";

            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Colaborador>(query, new { tipoId = tipo });
                return emplist.ToList();
            }
        }
      
    }
}
