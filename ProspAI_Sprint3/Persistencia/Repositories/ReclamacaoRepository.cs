using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Persistencia.Repositories
{
    public class ReclamacaoRepository : Repository<Reclamacao>
    {
        public ReclamacaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
