using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospisim.Data;
using Hospisim.Models.Entities;

namespace Hospisim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private readonly HospisimDbContext _context;

        public ProntuariosController(HospisimDbContext context)
        {
            _context = context;
        }

        // GET: api/Prontuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prontuario>>> GetProntuarios()
        {
            return await _context.Prontuarios.ToListAsync();
        }

        // GET: api/Prontuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prontuario>> GetProntuario(Guid id)
        {
            var prontuario = await _context.Prontuarios.FindAsync(id);

            if (prontuario == null)
            {
                return NotFound();
            }

            return prontuario;
        }

        // PUT: api/Prontuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProntuario(Guid id, Prontuario prontuario)
        {
            if (id != prontuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(prontuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProntuarioExists(id))
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

        // POST: api/Prontuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prontuario>> PostProntuario(Prontuario prontuario)
        {
            _context.Prontuarios.Add(prontuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProntuario", new { id = prontuario.Id }, prontuario);
        }

        // DELETE: api/Prontuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProntuario(Guid id)
        {
            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }

            _context.Prontuarios.Remove(prontuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProntuarioExists(Guid id)
        {
            return _context.Prontuarios.Any(e => e.Id == id);
        }
    }
}
