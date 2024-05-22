using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessClub.Models;

namespace FitnessClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly FitnessContext _context;

        public TrainersController(FitnessContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainers>>> GetTrainers()
        {
            return await _context.Trainers.ToListAsync();
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainers>> GetTrainers(long id)
        {
            var trainers = await _context.Trainers.FindAsync(id);

            if (trainers == null)
            {
                return NotFound();
            }

            return trainers;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainers(long id, Trainers trainers)
        {
            if (id != trainers.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainersExists(id))
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

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainers>> PostTrainers(Trainers trainers)
        {
            _context.Trainers.Add(trainers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainers", new { id = trainers.Id }, trainers);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainers(long id)
        {
            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainersExists(long id)
        {
            return _context.Trainers.Any(e => e.Id == id);
        }
    }
}
