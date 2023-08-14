using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmolenskTravelRESTFullAPI.Models;

namespace SmolenskTravelRESTFullAPI.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeToursController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public TypeToursController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/TypeTours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeTour>>> GetTypeTours()
        {
          if (_context.TypeTours == null)
          {
              return NotFound();
          }
            return await _context.TypeTours.ToListAsync();
        }

        // GET: api/TypeTours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeTour>> GetTypeTour(int id)
        {
          if (_context.TypeTours == null)
          {
              return NotFound();
          }
            var typeTour = await _context.TypeTours.FindAsync(id);

            if (typeTour == null)
            {
                return NotFound();
            }

            return typeTour;
        }

        // PUT: api/TypeTours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeTour(int id, TypeTour typeTour)
        {
            if (id != typeTour.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeTour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeTourExists(id))
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

        // POST: api/TypeTours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeTour>> PostTypeTour(TypeTour typeTour)
        {
          if (_context.TypeTours == null)
          {
              return Problem("Entity set 'SmolenskTravelContext.TypeTours'  is null.");
          }
            _context.TypeTours.Add(typeTour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeTour", new { id = typeTour.Id }, typeTour);
        }

        // DELETE: api/TypeTours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeTour(int id)
        {
            if (_context.TypeTours == null)
            {
                return NotFound();
            }
            var typeTour = await _context.TypeTours.FindAsync(id);
            if (typeTour == null)
            {
                return NotFound();
            }

            _context.TypeTours.Remove(typeTour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeTourExists(int id)
        {
            return (_context.TypeTours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
