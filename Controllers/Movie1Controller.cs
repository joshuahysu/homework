using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using homework.Data;
using homework.Models;

namespace homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movie1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Movie1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movie1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie1>>> GetMovie1()
        {
            return await _context.Movie1.ToListAsync();
        }

        // GET: api/Movie1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie1>> GetMovie1(int id)
        {
            var movie1 = await _context.Movie1.FindAsync(id);

            if (movie1 == null)
            {
                return NotFound();
            }

            return movie1;
        }

        // PUT: api/Movie1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie1(int id, Movie1 movie1)
        {
            if (id != movie1.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Movie1Exists(id))
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

        // POST: api/Movie1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie1>> PostMovie1(Movie1 movie1)
        {
            _context.Movie1.Add(movie1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie1", new { id = movie1.Id }, movie1);
        }

        // DELETE: api/Movie1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie1>> DeleteMovie1(int id)
        {
            var movie1 = await _context.Movie1.FindAsync(id);
            if (movie1 == null)
            {
                return NotFound();
            }

            _context.Movie1.Remove(movie1);
            await _context.SaveChangesAsync();

            return movie1;
        }

        private bool Movie1Exists(int id)
        {
            return _context.Movie1.Any(e => e.Id == id);
        }
    }
}
