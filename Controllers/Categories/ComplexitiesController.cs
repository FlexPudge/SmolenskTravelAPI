﻿using System;
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
    public class ComplexitiesController : ControllerBase
    {
        private readonly SmolenskTravelContext _context;

        public ComplexitiesController(SmolenskTravelContext context)
        {
            _context = context;
        }

        // GET: api/Complexities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complexity>>> GetComplexities()
        {
            if (_context.Complexities == null)
            {
                return NotFound();
            }
            return await _context.Complexities.ToListAsync();
        }

        // GET: api/Complexities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complexity>> GetComplexity(int id)
        {
            if (_context.Complexities == null)
            {
                return NotFound();
            }
            var complexity = await _context.Complexities.FindAsync(id);

            if (complexity == null)
            {
                return NotFound();
            }

            return complexity;
        }

        // PUT: api/Complexities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplexity(int id, Complexity complexity)
        {
            if (id != complexity.Id)
            {
                return BadRequest();
            }

            _context.Entry(complexity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexityExists(id))
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

        // POST: api/Complexities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Complexity>> PostComplexity(Complexity complexity)
        {
            if (_context.Complexities == null)
            {
                return Problem("Entity set 'SmolenskTravelContext.Complexities'  is null.");
            }
            _context.Complexities.Add(complexity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplexity", new { id = complexity.Id }, complexity);
        }

        // DELETE: api/Complexities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplexity(int id)
        {
            if (_context.Complexities == null)
            {
                return NotFound();
            }
            var complexity = await _context.Complexities.FindAsync(id);
            if (complexity == null)
            {
                return NotFound();
            }

            _context.Complexities.Remove(complexity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComplexityExists(int id)
        {
            return (_context.Complexities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
