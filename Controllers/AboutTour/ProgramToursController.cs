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
    public class ProgramToursController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public ProgramToursController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/ProgramTours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramTour>>> GetProgramTours()
        {
          if (_context.ProgramTours == null)
          {
              return NotFound();
          }
            return await _context.ProgramTours.ToListAsync();
        }

        // GET: api/ProgramTours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramTour>> GetProgramTour(int id)
        {
          if (_context.ProgramTours == null)
          {
              return NotFound();
          }
            var programTour = await _context.ProgramTours.FindAsync(id);

            if (programTour == null)
            {
                return NotFound();
            }

            return programTour;
        }

        // PUT: api/ProgramTours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramTour(int id, ProgramTour programTour)
        {
            if (id != programTour.Id)
            {
                return BadRequest();
            }

            _context.Entry(programTour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramTourExists(id))
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

        // POST: api/ProgramTours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramTour>> PostProgramTour(ProgramTour programTour)
        {
          if (_context.ProgramTours == null)
          {
              return Problem("Entity set 'SmolenskTravelContext.ProgramTours'  is null.");
          }
            _context.ProgramTours.Add(programTour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramTour", new { id = programTour.Id }, programTour);
        }

        // DELETE: api/ProgramTours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramTour(int id)
        {
            if (_context.ProgramTours == null)
            {
                return NotFound();
            }
            var programTour = await _context.ProgramTours.FindAsync(id);
            if (programTour == null)
            {
                return NotFound();
            }

            _context.ProgramTours.Remove(programTour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramTourExists(int id)
        {
            return (_context.ProgramTours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
