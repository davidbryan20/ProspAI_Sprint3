namespace ProspAI_Sprint3.Persistencia.Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioById(int id);
        Task AddFuncionario(Funcionario funcionario);
        Task UpdateFuncionario(Funcionario funcionario);
        Task DeleteFuncionario(int id);
    }
}
