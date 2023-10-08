using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelLove;
using TravelLove.Models;

namespace TravelLove.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    [Route("api/[controller]")]
   
    public class BusDetailsController : ControllerBase
    {
        private readonly TravelLoveDbContext _context;

        public BusDetailsController(TravelLoveDbContext context)
        {
            _context = context;
        }

        // GET: api/BusDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusDetails>>> GetBus()
        {
            return await _context.Bus.ToListAsync();
        }


        // GET: api/BusDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusDetails>> GetBusDetails(int id)
        {
            var busDetails = await _context.Bus.FindAsync(id);

            if (busDetails == null)
            {
                return NotFound();
            }

            return busDetails;
        }

        // PUT: api/BusDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusDetails(int id, BusDetails busDetails)
        {
            if (id != busDetails.BusId)
            {
                return BadRequest();
            }

            _context.Entry(busDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusDetailsExists(id))
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
        [HttpPut("update-seats/{busId}")]
        public async Task<IActionResult> UpdateSeats(int busId, [FromBody] BusSeatUpdateDTO seatUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bus = await _context.BusDetails.FindAsync(busId);

            if (bus == null)
            {
                return NotFound();
            }

            // Update the seat counts
            bus.FirstAC = seatUpdateDTO.FirstAC;
            bus.SecondAC = seatUpdateDTO.SecondAC;
            bus.Sleeper = seatUpdateDTO.Sleeper;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusDetailsExists(busId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        // POST: api/BusDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusDetails>> PostBusDetails(BusDetails busDetails)
        {
            _context.Bus.Add(busDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusDetails", new { id = busDetails.BusId }, busDetails);
        }

        // DELETE: api/BusDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusDetails>> DeleteBusDetails(int id)
        {
            var busDetails = await _context.Bus.FindAsync(id);
            if (busDetails == null)
            {
                return NotFound();
            }

            _context.Bus.Remove(busDetails);
            await _context.SaveChangesAsync();

            return busDetails;
        }

        private bool BusDetailsExists(int id)
        {
            return _context.Bus.Any(e => e.BusId == id);
        }
    }
}
