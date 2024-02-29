using SalaoDeBeleza.Model;

namespace SalaoDeBeleza.Repository
{
    public interface IManutencaoRepository
    {
        Task<List<Manutencao>> GetAll();
        Task<List<Manutencao>> GetManutencaoCombo(); 
        Task<List<Manutencao>> GetByTipo(int tipo);
        Task<Manutencao> GetbyId(int id);
        Task<string> Create(Manutencao colaborador);
        Task<string> Update(Manutencao tipo);
        Task<int> Remove(int Id);


    }
}
