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
    public class FishesController : ControllerBase
    {
        private readonly FishmanContext _context;

        public FishesController(FishmanContext context)
        {
            _context = context;
        }

        // GET: api/Fishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fishes>>> GetFishes()
        {
            return await _context.Fishes.ToListAsync();
        }

        // GET: api/Fishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fishes>> GetFishes(int id)
        {
            var fishes = await _context.Fishes.FindAsync(id);

            if (fishes == null)
            {
                return NotFound();
            }

            return fishes;
        }

        // PUT: api/Fishes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFishes(int id, Fishes fishes)
        {
            if (id != fishes.FishId)
            {
                return BadRequest();
            }

            _context.Entry(fishes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FishesExists(id))
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

        // POST: api/Fishes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fishes>> PostFishes(Fishes fishes)
        {
            _context.Fishes.Add(fishes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFishes", new { id = fishes.FishId }, fishes);
        }

        // DELETE: api/Fishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fishes>> DeleteFishes(int id)
        {
            var fishes = await _context.Fishes.FindAsync(id);
            if (fishes == null)
            {
                return NotFound();
            }

            _context.Fishes.Remove(fishes);
            await _context.SaveChangesAsync();

            return fishes;
        }

        private bool FishesExists(int id)
        {
            return _context.Fishes.Any(e => e.FishId == id);
        }
    }
}
