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
    public class AltaHospitalarsController : ControllerBase
    {
        private readonly HospisimDbContext _context;

        public AltaHospitalarsController(HospisimDbContext context)
        {
            _context = context;
        }

        // GET: api/AltaHospitalars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AltaHospitalar>>> GetAltasHospitalares()
        {
            return await _context.AltasHospitalares.ToListAsync();
        }

        // GET: api/AltaHospitalars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AltaHospitalar>> GetAltaHospitalar(Guid id)
        {
            var altaHospitalar = await _context.AltasHospitalares.FindAsync(id);

            if (altaHospitalar == null)
            {
                return NotFound();
            }

            return altaHospitalar;
        }

        // PUT: api/AltaHospitalars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAltaHospitalar(Guid id, AltaHospitalar altaHospitalar)
        {
            if (id != altaHospitalar.Id)
            {
                return BadRequest();
            }

            _context.Entry(altaHospitalar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AltaHospitalarExists(id))
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

        // POST: api/AltaHospitalars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AltaHospitalar>> PostAltaHospitalar(AltaHospitalar altaHospitalar)
        {
            _context.AltasHospitalares.Add(altaHospitalar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAltaHospitalar", new { id = altaHospitalar.Id }, altaHospitalar);
        }

        // DELETE: api/AltaHospitalars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAltaHospitalar(Guid id)
        {
            var altaHospitalar = await _context.AltasHospitalares.FindAsync(id);
            if (altaHospitalar == null)
            {
                return NotFound();
            }

            _context.AltasHospitalares.Remove(altaHospitalar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AltaHospitalarExists(Guid id)
        {
            return _context.AltasHospitalares.Any(e => e.Id == id);
        }
    }
}
