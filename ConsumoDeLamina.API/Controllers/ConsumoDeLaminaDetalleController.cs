using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsumoDeLamina.Data;
using ConsumoDeLamina.Entities.Models;

namespace ConsumoDeLamina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoDeLaminaDetalleController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public ConsumoDeLaminaDetalleController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/ConsumoDeLaminaDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoDeLaminaDetalles>>> GetConsumoDeLaminaDetalles()
        {
            return await _context.ConsumoDeLaminaDetalles.ToListAsync();
        }

        // GET: api/ConsumoDeLaminaDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoDeLaminaDetalles>> GetConsumoDeLaminaDetalles(int id)
        {
            var consumoDeLaminaDetalles = await _context.ConsumoDeLaminaDetalles.FindAsync(id);

            if (consumoDeLaminaDetalles == null)
            {
                return NotFound();
            }

            return consumoDeLaminaDetalles;
        }

        // PUT: api/ConsumoDeLaminaDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoDeLaminaDetalles(int id, ConsumoDeLaminaDetalles consumoDeLaminaDetalles)
        {
            if (id != consumoDeLaminaDetalles.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumoDeLaminaDetalles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoDeLaminaDetallesExists(id))
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

        // POST: api/ConsumoDeLaminaDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsumoDeLaminaDetalles>> PostConsumoDeLaminaDetalles(ConsumoDeLaminaDetalles consumoDeLaminaDetalles)
        {
            _context.ConsumoDeLaminaDetalles.Add(consumoDeLaminaDetalles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumoDeLaminaDetalles", new { id = consumoDeLaminaDetalles.Id }, consumoDeLaminaDetalles);
        }

        // DELETE: api/ConsumoDeLaminaDetalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoDeLaminaDetalles(int id)
        {
            var consumoDeLaminaDetalles = await _context.ConsumoDeLaminaDetalles.FindAsync(id);
            if (consumoDeLaminaDetalles == null)
            {
                return NotFound();
            }

            _context.ConsumoDeLaminaDetalles.Remove(consumoDeLaminaDetalles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumoDeLaminaDetallesExists(int id)
        {
            return _context.ConsumoDeLaminaDetalles.Any(e => e.Id == id);
        }
    }
}
