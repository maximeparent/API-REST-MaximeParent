using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly ApiContext _context;
        public InterventionsController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET: api/interventions/pending
        [HttpGet("pending")]
        public List<Intervention> GetStatus()
        {
            return _context.interventions.Where(i => i.status == "Pending" && i.start_date == null).ToList();
        }

        // GET: api/interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> Getinterventions(long id)
        {
            var interventions = await _context.interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }
            return interventions;
        }
        // PUT: api/interventions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinterventions(long id, Intervention interventions)
        {
            if (id != interventions.id)
            {
                return BadRequest();
            }
            _context.Entry(interventions).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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
        // POST: api/interventions
        [HttpPost]
        public async Task<ActionResult<Intervention>> Postinterventions(Intervention interventions)
        {
            _context.interventions.Add(interventions);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("Getinterventions", new { id = interventions.Id }, interventions);
            return CreatedAtAction(nameof(Getinterventions), new { id = interventions.id }, interventions);
        }
        // DELETE: api/interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Intervention>> Deleteinterventions(long id)
        {
            var interventions = await _context.interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }
            _context.interventions.Remove(interventions);
            await _context.SaveChangesAsync();
            return interventions;
        }
        private bool interventionsExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }
    }
}