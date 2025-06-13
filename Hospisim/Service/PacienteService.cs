using Hospisim.Data;
using Hospisim.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly HospisimDbContext _context;

        public PacienteService(HospisimDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> ObterPorIdAsync(Guid id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> CriarAsync(Paciente paciente)
        {
            if (await ExisteCpfAsync(paciente.CPF))
                throw new Exception("Já existe um paciente com esse CPF.");

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente?> AtualizarAsync(Guid id, Paciente paciente)
        {
            var existente = await _context.Pacientes.FindAsync(id);
            if (existente == null) return null;

            if (existente.CPF != paciente.CPF && await ExisteCpfAsync(paciente.CPF))
                throw new Exception("CPF já cadastrado para outro paciente.");

            existente.NomeCompleto = paciente.NomeCompleto;
            existente.CPF = paciente.CPF;
            existente.DataNascimento = paciente.DataNascimento;
            existente.Sexo = paciente.Sexo;
            existente.TipoSanguineo = paciente.TipoSanguineo;
            existente.Telefone = paciente.Telefone;
            existente.Email = paciente.Email;
            existente.EnderecoCompleto = paciente.EnderecoCompleto;
            existente.NumeroCartaoSUS = paciente.NumeroCartaoSUS;
            existente.EstadoCivil = paciente.EstadoCivil;
            existente.PossuiPlanoSaude = paciente.PossuiPlanoSaude;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            return await _context.Pacientes.AnyAsync(p => p.CPF == cpf);
        }
    }
}
