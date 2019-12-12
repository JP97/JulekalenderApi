using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JulekalenderApi.Data;
using JulekalenderApi.Models;

namespace JulekalenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TippsController : ControllerBase
    {
        private readonly JulekalenderApiContext _context;

        public TippsController(JulekalenderApiContext context)
        {
            _context = context;
        }

        // GET: api/Tipps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipp>>> GetTipps()
        {
            return await _context.Tipps.ToListAsync();
        }

        // GET: api/Tipps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipp>> GetTipps(int id)
        {
            var tipps = await _context.Tipps.FindAsync(id);

            if (tipps == null)
            {
                return NotFound();
            }

            return tipps;
        }

        // PUT: api/Tipps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipps(int id, Tipp tipp)
        {
            if (id != tipp.TippID)
            {
                return BadRequest();
            }

            _context.Entry(tipp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeExists(id))
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

        // POST: api/Tipps
        [HttpPost]
        public async Task<ActionResult<Tipp>> PostTipps(Tipp tipp)
        {
            _context.Tipps.Add(tipp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnowledge", new { id = tipp.TippID }, tipp);
        }

        // DELETE: api/Tipps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipp>> DeleteTipps(int id)
        {
            var knowledge = await _context.Tipps.FindAsync(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            _context.Tipps.Remove(knowledge);
            await _context.SaveChangesAsync();

            return knowledge;
        }

        private bool KnowledgeExists(int id)
        {
            return _context.Tipps.Any(e => e.TippID == id);
        }
    }
}
