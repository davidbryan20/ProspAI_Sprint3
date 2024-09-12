using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public interface IReclamacaoService
    {
        Task<IEnumerable<Reclamacao>> GetAllReclamacoes();
        Task<Reclamacao> GetReclamacaoById(int id);
        Task AddReclamacao(Reclamacao reclamacao);
        Task UpdateReclamacao(Reclamacao reclamacao);
        Task DeleteReclamacao(int id);
    }
}
