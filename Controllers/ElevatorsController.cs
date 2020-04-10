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
    public class ElevatorsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ElevatorsController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }

        // GET: api/elevators/unavailable
        [HttpGet("unavailable")]
        public List<Elevator> Getstatus(string status)
        {
            var unavailable = _context.elevators.Where(e => e.status != "Active").ToList();
            return unavailable;
        }

        // GET: api/elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> Getelevators(long id)
        {
            var elevators = await _context.elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }
            return elevators;
        }

        // PUT: api/elevators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putelevators(long id, Elevator elevators)
        {
            if (id != elevators.id)
            {
                return BadRequest();
            }
            _context.Entry(elevators).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elevatorsExists(id))
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
        // POST: api/elevators
        [HttpPost]
        public async Task<ActionResult<Elevator>> Postelevators(Elevator elevators)
        {
            _context.elevators.Add(elevators);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Getelevators), new { id = elevators.id }, elevators);
        }

        // DELETE: api/elevators/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevator>> Deleteelevators(long id)
        {
            var elevators = await _context.elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }
            _context.elevators.Remove(elevators);
            await _context.SaveChangesAsync();
            return elevators;
        }
        private bool elevatorsExists(long id)
        {
            return _context.elevators.Any(e => e.id == id);
        }
    }
}