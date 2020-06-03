using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fishman.Models;

namespace Fishman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalersController : ControllerBase
    {
        private readonly FishmanContext _context;

        public SalersController(FishmanContext context)
        {
            _context = context;
        }

        // GET: api/Salers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salers>>> GetSalers()
        {
            return await _context.Salers.ToListAsync();
        }

        // GET: api/Salers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salers>> GetSalers(int id)
        {
            var salers = await _context.Salers.FindAsync(id);

            if (salers == null)
            {
                return NotFound();
            }

            return salers;
        }

        // PUT: api/Salers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalers(int id, Salers salers)
        {
            if (id != salers.SalerId)
            {
                return BadRequest();
            }

            _context.Entry(salers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalersExists(id))
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

        // POST: api/Salers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Salers>> PostSalers(Salers salers)
        {
            _context.Salers.Add(salers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalers", new { id = salers.SalerId }, salers);
        }

        // DELETE: api/Salers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Salers>> DeleteSalers(int id)
        {
            var salers = await _context.Salers.FindAsync(id);
            if (salers == null)
            {
                return NotFound();
            }

            _context.Salers.Remove(salers);
            await _context.SaveChangesAsync();

            return salers;
        }

        private bool SalersExists(int id)
        {
            return _context.Salers.Any(e => e.SalerId == id);
        }
    }
}
