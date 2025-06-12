using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HOSPISIM.Models;
using Hospisim.Data;

namespace Hospisim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalSaudesController : ControllerBase
    {
        private readonly HospisimDbContext _context;

        public ProfissionalSaudesController(HospisimDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfissionalSaudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfissionalSaude>>> GetProfissionaisSaude()
        {
            return await _context.ProfissionaisSaude.ToListAsync();
        }

        // GET: api/ProfissionalSaudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfissionalSaude>> GetProfissionalSaude(Guid id)
        {
            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);

            if (profissionalSaude == null)
            {
                return NotFound();
            }

            return profissionalSaude;
        }

        // PUT: api/ProfissionalSaudes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfissionalSaude(Guid id, ProfissionalSaude profissionalSaude)
        {
            if (id != profissionalSaude.Id)
            {
                return BadRequest();
            }

            _context.Entry(profissionalSaude).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalSaudeExists(id))
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

        // POST: api/ProfissionalSaudes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfissionalSaude>> PostProfissionalSaude(ProfissionalSaude profissionalSaude)
        {
            _context.ProfissionaisSaude.Add(profissionalSaude);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfissionalSaude", new { id = profissionalSaude.Id }, profissionalSaude);
        }

        // DELETE: api/ProfissionalSaudes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfissionalSaude(Guid id)
        {
            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);
            if (profissionalSaude == null)
            {
                return NotFound();
            }

            _context.ProfissionaisSaude.Remove(profissionalSaude);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfissionalSaudeExists(Guid id)
        {
            return _context.ProfissionaisSaude.Any(e => e.Id == id);
        }
    }
}
