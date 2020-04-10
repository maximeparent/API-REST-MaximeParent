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
    public class LeadsController : ControllerBase
    {
        private readonly ApiContext _context;
        public LeadsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> Getleads()
        {
            return await _context.leads.ToListAsync();
        }

        // GET: api/leads/available
        [HttpGet("notacustomer")]
        public List<Lead> Getnotacustomer()
        {
            List<Lead> contacts = _context.leads.ToList();
            List<Customer> existingCustomer = _context.customers.ToList();

            List<Lead> leadsList = new List<Lead>();
            var dateMax = DateTime.Now.AddDays(-30);

            foreach(var test in contacts){
                if(test.date > dateMax) {
                    bool foundCustomer = false;
                    foreach(var mycustomer in existingCustomer) {
                        if(test.businessname == mycustomer.company_name) {
                            foundCustomer = true;
                        }
                    }
                    if(!foundCustomer) {
                        leadsList.Add(test);
                    }
                }
            }
            return leadsList.ToList();
        }

        // PUT: api/leads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putleads(long id, Lead leads)
        {
            if (id != leads.id)
            {
                return BadRequest();
            }
            _context.Entry(leads).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!leadsExists(id))
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
        
        // POST: api/leads
        [HttpPost]
        public async Task<ActionResult<Lead>> Postleads(Lead leads)
        {
            _context.leads.Add(leads);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("Getleads", new { id = leads.Id }, leads);
            return CreatedAtAction(nameof(Getleads), new { id = leads.id }, leads);
        }

        // DELETE: api/leads/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lead>> Deleteleads(long id)
        {
            var leads = await _context.leads.FindAsync(id);
            if (leads == null)
            {
                return NotFound();
            }
            _context.leads.Remove(leads);
            await _context.SaveChangesAsync();
            return leads;
        }
        private bool leadsExists(long id)
        {
            return _context.leads.Any(e => e.id == id);
        }
    }
}