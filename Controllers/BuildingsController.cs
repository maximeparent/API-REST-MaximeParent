using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly ApiContext _context;
        public BuildingsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> Getbuildings()
        {
            return await _context.buildings.ToListAsync();
        }

        // GET: api/buildings/unavailable
        [HttpGet("intervention")]
        public List<Building> Getintervention(string status)
        {
            var elevatorz = _context.buildings.Where(a => a.batteries.SelectMany(b => b.columns).SelectMany(c => c.elevators).Any(c => c.status == "Intervention")).ToList();
            var columnz = _context.buildings.Where(a => a.batteries.SelectMany(b => b.columns).Any(b => b.status == "Intervention")).ToList();
            var batteryz = _context.buildings.Where(a => a.batteries.Any(a => a.status == "Intervention")).ToList();
            var intervention = elevatorz.Union(columnz).Union(batteryz).OrderBy(building => building.id).ToList();

            return intervention;
        }

        // GET: api/buildings/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> Getbuildings(long id)
        {
            var buildings = await _context.buildings.FindAsync(id);
            if (buildings == null)
            {
                return NotFound();
            }
            return buildings;
        }

        // PUT: api/buildings/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbuildings(long id, Building buildings)
        {
            if (id != buildings.id)
            {
                return BadRequest();
            }
            _context.Entry(buildings).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!buildingsExists(id))
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
        
        // POST: api/buildings
        [HttpPost]
        public async Task<ActionResult<Building>> Postbuildings(Building buildings)
        {
            _context.buildings.Add(buildings);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Getbuildings), new { id = buildings.id }, buildings);
        }

        // DELETE: api/buildings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Building>> Deletebuildings(long id)
        {
            var buildings = await _context.buildings.FindAsync(id);
            if (buildings == null)
            {
                return NotFound();
            }
            _context.buildings.Remove(buildings);
            await _context.SaveChangesAsync();
            return buildings;
        }
        private bool buildingsExists(long id)
        {
            return _context.buildings.Any(e => e.id == id);
        }
    }
}