using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Persistencia.Repositories;
using ProspAI_Sprint3.Persistencia.Repositories.challenge_sprint2.Repositories;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public class DesempenhoService : IDesempenhoService
    {
        private readonly IRepository<Desempenho> _desempenhoRepository;

        public DesempenhoService(IRepository<Desempenho> desempenhoRepository)
        {
            _desempenhoRepository = desempenhoRepository;
        }

        public async Task<IEnumerable<Desempenho>> GetAllDesempenhos()
        {
            return await _desempenhoRepository.GetAllAsync();
        }

        public async Task<Desempenho> GetDesempenhoById(int id)
        {
            return await _desempenhoRepository.GetByIdAsync(id);
        }

        public async Task AddDesempenho(Desempenho desempenho)
        {
            await _desempenhoRepository.AddAsync(desempenho);
        }

        public async Task UpdateDesempenho(Desempenho desempenho)
        {
            await _desempenhoRepository.UpdateAsync(desempenho);
        }

        public async Task DeleteDesempenho(int id)
        {
            await _desempenhoRepository.DeleteAsync(id);
        }
    }
}
