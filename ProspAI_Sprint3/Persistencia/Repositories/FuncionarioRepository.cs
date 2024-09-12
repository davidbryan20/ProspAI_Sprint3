using ProspAI_Sprint3.Data;
using System;

namespace ProspAI_Sprint3.Persistencia.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>
    {
        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
