﻿using System;
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
    public class ExamesController : ControllerBase
    {
        private readonly HospisimDbContext _context;

        public ExamesController(HospisimDbContext context)
        {
            _context = context;
        }

        // GET: api/Exames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exame>>> GetExames()
        {
            return await _context.Exames.ToListAsync();
        }

        // GET: api/Exames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exame>> GetExame(Guid id)
        {
            var exame = await _context.Exames.FindAsync(id);

            if (exame == null)
            {
                return NotFound();
            }

            return exame;
        }

        // PUT: api/Exames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExame(Guid id, Exame exame)
        {
            if (id != exame.Id)
            {
                return BadRequest();
            }

            _context.Entry(exame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExameExists(id))
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

        // POST: api/Exames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exame>> PostExame(Exame exame)
        {
            _context.Exames.Add(exame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExame", new { id = exame.Id }, exame);
        }

        // DELETE: api/Exames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExame(Guid id)
        {
            var exame = await _context.Exames.FindAsync(id);
            if (exame == null)
            {
                return NotFound();
            }

            _context.Exames.Remove(exame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExameExists(Guid id)
        {
            return _context.Exames.Any(e => e.Id == id);
        }
    }
}
