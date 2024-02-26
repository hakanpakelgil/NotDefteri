using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotDefteriApi.Data;

namespace NotDefteriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotlarController : ControllerBase
    {
        private readonly UygulamaDbContext _context;

        public NotlarController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: api/Notlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Not>>> GetNotlar()
        {
            return await _context.Notlar.ToListAsync();
        }

        // GET: api/Notlar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Not>> GetNot(int id)
        {
            var @not = await _context.Notlar.FindAsync(id);

            if (@not == null)
            {
                return NotFound();
            }

            return @not;
        }

        // PUT: api/Notlar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNot(int id, Not @not)
        {
            if (id != @not.Id)
            {
                return BadRequest();
            }

            _context.Entry(@not).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotExists(id))
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

        // POST: api/Notlar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Not>> PostNot(Not @not)
        {
            _context.Notlar.Add(@not);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNot", new { id = @not.Id }, @not);
        }

        // DELETE: api/Notlar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNot(int id)
        {
            var @not = await _context.Notlar.FindAsync(id);
            if (@not == null)
            {
                return NotFound();
            }

            _context.Notlar.Remove(@not);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotExists(int id)
        {
            return _context.Notlar.Any(e => e.Id == id);
        }
    }
}
