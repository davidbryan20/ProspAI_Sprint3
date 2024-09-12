using ProspAI_Sprint3.Persistencia.Repositories.challenge_sprint2.Repositories;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IRepository<Funcionario> _funcionarioRepository;

        public FuncionarioService(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            return await _funcionarioRepository.GetAllAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            return await _funcionarioRepository.GetByIdAsync(id);
        }

        public async Task AddFuncionario(Funcionario funcionario)
        {
            await _funcionarioRepository.AddAsync(funcionario);
        }

        public async Task UpdateFuncionario(Funcionario funcionario)
        {
            await _funcionarioRepository.UpdateAsync(funcionario);
        }

        public async Task DeleteFuncionario(int id)
        {
            await _funcionarioRepository.DeleteAsync(id);
        }
    }
}
