using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Persistencia.Repositories;
using ProspAI_Sprint3.Persistencia.Repositories.challenge_sprint2.Repositories;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public class ReclamacaoService : IReclamacaoService
    {
        private readonly IRepository<Reclamacao> _reclamacaoRepository;

        public ReclamacaoService(IRepository<Reclamacao> reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

        public async Task<IEnumerable<Reclamacao>> GetAllReclamacoes()
        {
            return await _reclamacaoRepository.GetAllAsync();
        }

        public async Task<Reclamacao> GetReclamacaoById(int id)
        {
            return await _reclamacaoRepository.GetByIdAsync(id);
        }

        public async Task AddReclamacao(Reclamacao reclamacao)
        {
            await _reclamacaoRepository.AddAsync(reclamacao);
        }

        public async Task UpdateReclamacao(Reclamacao reclamacao)
        {
            await _reclamacaoRepository.UpdateAsync(reclamacao);
        }

        public async Task DeleteReclamacao(int id)
        {
            await _reclamacaoRepository.DeleteAsync(id);
        }
    }
}
