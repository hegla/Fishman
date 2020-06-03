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
    public class CitySalersController : ControllerBase
    {
        private readonly FishmanContext _context;

        public CitySalersController(FishmanContext context)
        {
            _context = context;
        }

        // GET: api/CitySalers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitySalers>>> GetCitySalers()
        {
            return await _context.CitySalers.ToListAsync();
        }

        // GET: api/CitySalers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitySalers>> GetCitySalers(int id)
        {
            var citySalers = await _context.CitySalers.FindAsync(id);

            if (citySalers == null)
            {
                return NotFound();
            }

            return citySalers;
        }

        // PUT: api/CitySalers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitySalers(int id, CitySalers citySalers)
        {
            if (id != citySalers.Id)
            {
                return BadRequest();
            }

            _context.Entry(citySalers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitySalersExists(id))
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

        // POST: api/CitySalers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CitySalers>> PostCitySalers(CitySalers citySalers)
        {
            _context.CitySalers.Add(citySalers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitySalers", new { id = citySalers.Id }, citySalers);
        }

        // DELETE: api/CitySalers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CitySalers>> DeleteCitySalers(int id)
        {
            var citySalers = await _context.CitySalers.FindAsync(id);
            if (citySalers == null)
            {
                return NotFound();
            }

            _context.CitySalers.Remove(citySalers);
            await _context.SaveChangesAsync();

            return citySalers;
        }

        private bool CitySalersExists(int id)
        {
            return _context.CitySalers.Any(e => e.Id == id);
        }
    }
}
