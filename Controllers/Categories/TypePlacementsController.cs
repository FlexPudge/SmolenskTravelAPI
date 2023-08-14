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
    public class TypePlacementsController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public TypePlacementsController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/TypePlacements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePlacement>>> GetTypePlacements()
        {
          if (_context.TypePlacements == null)
          {
              return NotFound();
          }
            return await _context.TypePlacements.ToListAsync();
        }

        // GET: api/TypePlacements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePlacement>> GetTypePlacement(int id)
        {
          if (_context.TypePlacements == null)
          {
              return NotFound();
          }
            var typePlacement = await _context.TypePlacements.FindAsync(id);

            if (typePlacement == null)
            {
                return NotFound();
            }

            return typePlacement;
        }

        // PUT: api/TypePlacements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePlacement(int id, TypePlacement typePlacement)
        {
            if (id != typePlacement.Id)
            {
                return BadRequest();
            }

            _context.Entry(typePlacement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePlacementExists(id))
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

        // POST: api/TypePlacements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypePlacement>> PostTypePlacement(TypePlacement typePlacement)
        {
          if (_context.TypePlacements == null)
          {
              return Problem("Entity set 'SmolenskTravelContext.TypePlacements'  is null.");
          }
            _context.TypePlacements.Add(typePlacement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePlacement", new { id = typePlacement.Id }, typePlacement);
        }

        // DELETE: api/TypePlacements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePlacement(int id)
        {
            if (_context.TypePlacements == null)
            {
                return NotFound();
            }
            var typePlacement = await _context.TypePlacements.FindAsync(id);
            if (typePlacement == null)
            {
                return NotFound();
            }

            _context.TypePlacements.Remove(typePlacement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypePlacementExists(int id)
        {
            return (_context.TypePlacements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
