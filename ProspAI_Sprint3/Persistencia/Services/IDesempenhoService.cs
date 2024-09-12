using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Persistencia.Services
{
        public interface IDesempenhoService
        {
            Task<IEnumerable<Desempenho>> GetAllDesempenhos();
            Task<Desempenho> GetDesempenhoById(int id);
            Task AddDesempenho(Desempenho desempenho);
            Task UpdateDesempenho(Desempenho desempenho);
            Task DeleteDesempenho(int id);
        }
}