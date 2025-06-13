using Hospisim.Models.Entities;

namespace Hospisim.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente?> ObterPorIdAsync(Guid id);
        Task<Paciente> CriarAsync(Paciente paciente);
        Task<Paciente?> AtualizarAsync(Guid id, Paciente paciente);
        Task<bool> DeletarAsync(Guid id);
        Task<bool> ExisteCpfAsync(string cpf);
    }
}
