using Microsoft.AspNetCore.Mvc;
using Hospisim.Models.Entities;
using Hospisim.Services;

namespace Hospisim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _pacienteService.ObterTodosAsync();
            return Ok(pacientes);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(Guid id)
        {
            var paciente = await _pacienteService.ObterPorIdAsync(id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        // POST: api/Pacientes
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            try
            {
                var novoPaciente = await _pacienteService.CriarAsync(paciente);
                return CreatedAtAction(nameof(GetPaciente), new { id = novoPaciente.Id }, novoPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // PUT: api/Pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(Guid id, Paciente paciente)
        {
            if (id != paciente.Id)
                return BadRequest("O ID da URL não corresponde ao paciente informado.");

            try
            {
                var atualizado = await _pacienteService.AtualizarAsync(id, paciente);
                if (atualizado == null) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(Guid id)
        {
            var sucesso = await _pacienteService.DeletarAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
