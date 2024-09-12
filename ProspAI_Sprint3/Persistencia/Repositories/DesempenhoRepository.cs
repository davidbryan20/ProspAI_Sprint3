using ProspAI_Sprint3.Data;
using ProspAI_Sprint3.Models;
using System;

namespace ProspAI_Sprint3.Persistencia.Repositories
{
    public class DesempenhoRepository : Repository<Desempenho>
    {
        public DesempenhoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
