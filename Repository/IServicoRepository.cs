using SalaoDeBeleza.Model;

namespace SalaoDeBeleza.Repository
{
    public interface IServicoRepository
    {
        Task<List<Servico>> GetAll();

        Task<List<Servico>> GetByTipo(int Nome);
        Task<Servico> GetbyId(int id);
        Task<string> Create(Servico nome);
        Task<string> Update(Servico nome, int Id);
        Task<string> Remove(int Id);


    }
}
