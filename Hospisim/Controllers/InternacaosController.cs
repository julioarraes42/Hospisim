using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospisim.Data;

namespace Hospisim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternacaosController : ControllerBase
    {
        private readonly HospisimDbContext _context;

        public InternacaosController(HospisimDbContext context)
        {
            _context = context;
        }

        // GET: api/Internacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Internacao>>> GetInternacoes()
        {
            return await _context.Internacoes.ToListAsync();
        }

        // GET: api/Internacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Internacao>> GetInternacao(Guid id)
        {
            var internacao = await _context.Internacoes.FindAsync(id);

            if (internacao == null)
            {
                return NotFound();
            }

            return internacao;
        }

        // PUT: api/Internacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternacao(Guid id, Internacao internacao)
        {
            if (id != internacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(internacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Internacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Internacao>> PostInternacao(Internacao internacao)
        {
            _context.Internacoes.Add(internacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInternacao", new { id = internacao.Id }, internacao);
        }

        // DELETE: api/Internacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternacao(Guid id)
        {
            var internacao = await _context.Internacoes.FindAsync(id);
            if (internacao == null)
            {
                return NotFound();
            }

            _context.Internacoes.Remove(internacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternacaoExists(Guid id)
        {
            return _context.Internacoes.Any(e => e.Id == id);
        }
    }
}
