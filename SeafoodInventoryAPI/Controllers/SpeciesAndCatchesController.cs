﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeafoodInventoryAPI.Models;

namespace SeafoodInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesAndCatchesController : ControllerBase
    {
        private readonly SeafoodDbContext _context;

        public SpeciesAndCatchesController(SeafoodDbContext context)
        {
            _context = context;
        }


        // GET: api/Species
        [HttpGet("Species")]
        public async Task<ActionResult<IEnumerable<Species>>> GetSpecies()
        {
            return await _context.Species.ToListAsync();
        }

        // GET: api/Catches
        [HttpGet("Catches")]
        public async Task<ActionResult<IEnumerable<Catches>>> GetCatches()
        {
            return await _context.Catches.ToListAsync();
        }

        [HttpGet("catches-with-species")]
        public async Task<ActionResult<IEnumerable<Catches>>> GetCatchesWithSpecies()
        {
            var catchesWithSpecies = await _context.Catches
                .Include(c => c.Species)
                .ToListAsync();

            return catchesWithSpecies;
        }

        // GET: api/Species/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Species>> GetSpecies(int id)
        {
            var species = await _context.Species.FindAsync(id);

            if (species == null)
            {
                return NotFound();
            }

            return species;
        }

        // PUT: api/Species/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecies(int id, Species species)
        {
            if (id != species.SpeciesId)
            {
                return BadRequest();
            }

            _context.Entry(species).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciesExists(id))
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

        // POST: api/Species
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Species>> PostSpecies(Species species)
        {
            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecies", new { id = species.SpeciesId }, species);
        }

        // DELETE: api/Species/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            var species = await _context.Species.FindAsync(id);
            if (species == null)
            {
                return NotFound();
            }

            _context.Species.Remove(species);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpeciesExists(int id)
        {
            return _context.Species.Any(e => e.SpeciesId == id);
        }
    }
}
