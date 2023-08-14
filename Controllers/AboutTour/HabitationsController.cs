using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmolenskTravelRESTFullAPI.Models;

namespace SmolenskTravelRESTFullAPI.Controllers.AboutTour
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitationsController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public HabitationsController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/Habitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitation>>> GetHabitations()
        {
            if (_context.Habitations == null)
            {
                return NotFound();
            }
            return await _context.Habitations.ToListAsync();
        }

        // GET: api/Habitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habitation>> GetHabitation(int id)
        {
            if (_context.Habitations == null)
            {
                return NotFound();
            }
            var habitation = await _context.Habitations.FindAsync(id);

            if (habitation == null)
            {
                return NotFound();
            }

            return habitation;
        }

        // PUT: api/Habitations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitation(int id, Habitation habitation)
        {
            if (id != habitation.Id)
            {
                return BadRequest();
            }

            _context.Entry(habitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitationExists(id))
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

        // POST: api/Habitations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habitation>> PostHabitation(Habitation habitation)
        {
            if (_context.Habitations == null)
            {
                return Problem("Entity set 'SmolenskTravelContext.Habitations'  is null.");
            }
            _context.Habitations.Add(habitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitation", new { id = habitation.Id }, habitation);
        }

        // DELETE: api/Habitations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitation(int id)
        {
            if (_context.Habitations == null)
            {
                return NotFound();
            }
            var habitation = await _context.Habitations.FindAsync(id);
            if (habitation == null)
            {
                return NotFound();
            }

            _context.Habitations.Remove(habitation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitationExists(int id)
        {
            return (_context.Habitations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
