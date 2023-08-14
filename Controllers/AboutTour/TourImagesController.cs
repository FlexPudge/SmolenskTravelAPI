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
    public class TourImagesController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public TourImagesController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/TourImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourImage>>> GetTourImages()
        {
          if (_context.TourImages == null)
          {
              return NotFound();
          }
            return await _context.TourImages.ToListAsync();
        }

        // GET: api/TourImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourImage>> GetTourImage(int id)
        {
          if (_context.TourImages == null)
          {
              return NotFound();
          }
            var tourImage = await _context.TourImages.FindAsync(id);

            if (tourImage == null)
            {
                return NotFound();
            }

            return tourImage;
        }

        // PUT: api/TourImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourImage(int id, TourImage tourImage)
        {
            if (id != tourImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(tourImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourImageExists(id))
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

        // POST: api/TourImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TourImage>> PostTourImage(TourImage tourImage)
        {
          if (_context.TourImages == null)
          {
              return Problem("Entity set 'SmolenskTravelContext.TourImages'  is null.");
          }
            _context.TourImages.Add(tourImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourImage", new { id = tourImage.Id }, tourImage);
        }

        // DELETE: api/TourImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourImage(int id)
        {
            if (_context.TourImages == null)
            {
                return NotFound();
            }
            var tourImage = await _context.TourImages.FindAsync(id);
            if (tourImage == null)
            {
                return NotFound();
            }

            _context.TourImages.Remove(tourImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourImageExists(int id)
        {
            return (_context.TourImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
