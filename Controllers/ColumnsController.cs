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
    public class ColumnsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ColumnsController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> Getcolumns()
        {
            return await _context.columns.ToListAsync();
        }
        // GET: api/columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> Getcolumns(long id)
        {
            var columns = await _context.columns.FindAsync(id);
            if (columns == null)
            {
                return NotFound();
            }
            return columns;
        }
        // PUT: api/columns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcolumns(long id, Column columns)
        {
            if (id != columns.id)
            {
                return BadRequest();
            }
            _context.Entry(columns).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!columnsExists(id))
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
        // POST: api/columns
        [HttpPost]
        public async Task<ActionResult<Column>> Postcolumns(Column columns)
        {
            _context.columns.Add(columns);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("Getcolumns", new { id = columns.Id }, columns);
            return CreatedAtAction(nameof(Getcolumns), new { id = columns.id }, columns);
        }
        // DELETE: api/columns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Column>> Deletecolumns(long id)
        {
            var columns = await _context.columns.FindAsync(id);
            if (columns == null)
            {
                return NotFound();
            }
            _context.columns.Remove(columns);
            await _context.SaveChangesAsync();
            return columns;
        }
        private bool columnsExists(long id)
        {
            return _context.columns.Any(e => e.id == id);
        }
    }
}