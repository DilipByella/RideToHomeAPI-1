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
    [Route("api/[controller]")]
    [ApiController]
    public class BankCredsController : ControllerBase
    {
        private readonly TravelLoveDbContext _context;

        public BankCredsController(TravelLoveDbContext context)
        {
            _context = context;
        }

        // GET: api/BankCreds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankCred>>> GetBankcred()
        {
            return await _context.Bankcred.ToListAsync();
        }

        // GET: api/BankCreds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankCred>> GetBankCred(int id)
        {
            var bankCred = await _context.Bankcred.FindAsync(id);

            if (bankCred == null)
            {
                return NotFound();
            }

            return bankCred;
        }

        // PUT: api/BankCreds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankCred(int id, BankCred bankCred)
        {
            if (id != bankCred.BankCredId)
            {
                return BadRequest();
            }

            _context.Entry(bankCred).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCredExists(id))
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

        // POST: api/BankCreds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BankCred>> PostBankCred(BankCred bankCred)
        {
            _context.Bankcred.Add(bankCred);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankCred", new { id = bankCred.BankCredId }, bankCred);
        }

        // DELETE: api/BankCreds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankCred>> DeleteBankCred(int id)
        {
            var bankCred = await _context.Bankcred.FindAsync(id);
            if (bankCred == null)
            {
                return NotFound();
            }

            _context.Bankcred.Remove(bankCred);
            await _context.SaveChangesAsync();

            return bankCred;
        }

        private bool BankCredExists(int id)
        {
            return _context.Bankcred.Any(e => e.BankCredId == id);
        }
    }
}
