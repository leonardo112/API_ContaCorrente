using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ContaCorrente.Context;
using API_ContaCorrente.Models;

namespace API_ContaCorrente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ContaCorrenteContext _context;

        public ContaCorrenteController(ContaCorrenteContext context)
        {
            _context = context;
        }

        // GET: api/ContaCorrente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaCorrente>>> GetcontaCorrentes()
        {
            return await _context.contaCorrentes.ToListAsync();
        }

        // GET: api/ContaCorrente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrente>> GetContaCorrente(int id)
        {
            var contaCorrente = await _context.contaCorrentes.FindAsync(id);

            if (contaCorrente == null)
            {
                return NotFound();
            }

            return contaCorrente;
        }

        // PUT: api/ContaCorrente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaCorrente(int id, ContaCorrente contaCorrente)
        {
            if (id != contaCorrente.ID)
            {
                return BadRequest();
            }

            _context.Entry(contaCorrente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaCorrenteExists(id))
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

        // POST: api/ContaCorrente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContaCorrente>> PostContaCorrente(ContaCorrente contaCorrente)
        {
            _context.contaCorrentes.Add(contaCorrente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContaCorrente", new { id = contaCorrente.ID }, contaCorrente);
        }

        // DELETE: api/ContaCorrente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContaCorrente>> DeleteContaCorrente(int id)
        {
            var contaCorrente = await _context.contaCorrentes.FindAsync(id);
            if (contaCorrente == null)
            {
                return NotFound();
            }

            _context.contaCorrentes.Remove(contaCorrente);
            await _context.SaveChangesAsync();

            return contaCorrente;
        }

        private bool ContaCorrenteExists(int id)
        {
            return _context.contaCorrentes.Any(e => e.ID == id);
        }
    }
}
