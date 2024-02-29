using SalaoDeBeleza.Model;

namespace SalaoDeBeleza.Repository
{
    public interface IColaboradorRepository
    {
        Task<List<Colaborador>> GetAll();

        Task<List<Colaborador>> GetByTipo(int tipo);
        Task<Colaborador> GetbyId(int id);
        Task<string> Create(Colaborador colaborador);
        Task<string> Update(Colaborador cliente);
        Task<int> Remove(int Id);


    }
}
