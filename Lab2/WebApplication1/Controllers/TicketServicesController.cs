using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketServicesController : ControllerBase
    {
        private readonly ServiceContext _context;

        public TicketServicesController(ServiceContext context)
        {
            _context = context;
        }

        // GET: api/TicketServices
        [HttpGet]
        public IEnumerable<TicketService> GetTicketService()
        {
            return _context.TicketService;
        }

        // GET: api/TicketServices/5
        [HttpGet("{id}")]
        public  IEnumerable<TicketService> GetTicketService([FromRoute] int id)
        {


            return _context.TicketService.Where(a=>a.ticketId==id);


        }

        // PUT: api/TicketServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketService([FromRoute] int id, [FromBody] TicketService ticketService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketService.ticketId)
            {
                return BadRequest();
            }

            _context.Entry(ticketService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketServiceExists(id))
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

        // POST: api/TicketServices
        [HttpPost]
        public async Task<IActionResult> PostTicketService([FromBody] TicketService ticketService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TicketService.Add(ticketService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketServiceExists(ticketService.ticketId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicketService", new { id = ticketService.ticketId }, ticketService);
        }

        // DELETE: api/TicketServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketService = await _context.TicketService.FindAsync(id);
            if (ticketService == null)
            {
                return NotFound();
            }

            _context.TicketService.Remove(ticketService);
            await _context.SaveChangesAsync();

            return Ok(ticketService);
        }

        private bool TicketServiceExists(int id)
        {
            return _context.TicketService.Any(e => e.ticketId == id);
        }
    }
}