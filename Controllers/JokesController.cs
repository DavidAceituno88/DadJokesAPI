using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DadJokesAPI.Models;

namespace DadJokesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly JokeDbContext _context;

        public JokesController(JokeDbContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            return await _context.Jokes.ToListAsync();
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            var joke = await _context.Jokes.FindAsync(id);

            if (joke == null)
            {using System;using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DadJokesAPI.Models;

namespace DadJokesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly JokeDbContext _context;

        public JokesController(JokeDbContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            return await _context.Jokes.ToListAsync();
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            var joke = await _context.Jokes.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return joke;
        }

        //Seed Method
        [HttpGet("seed")]
        public string Seed()
        {
            if (!_context.Jokes.Any())
            {
                List<Joke> jokes = new List<Joke>
            {
                new Joke {Category = "General", Setup="I don't trust those trees", Punch="They seem kind of shady."},
                new Joke {Category = "Wife", Setup="My wife is really mad at the fact that I have no sense of direction", Punch="So I packed up my stuff and right!"},
                new Joke {Category = "Sports", Setup="Why couldn't the bicycle stand up by itself?", Punch="It was two tired."},
                new Joke {Category = "General", Setup="What did the ocean say to the beach?", Punch="Nothing, it just waved."},
                new Joke {Category = "Knok-Knock", Setup="Knock knock. Who's there? Spell. Spell who?", Punch="Okay, fine. W-H-O!"},
                new Joke {Category = "Wife", Setup="My wife said I should do lunges to stay in shape.", Punch="That would be a big step forward."},
                new Joke {Category = "Knok-Knock", Setup="nock knock. Who's there? I am. I am who? ", Punch="I am who is knocking. Who are you?"},
                new Joke {Category = "Sports", Setup="What does a sprinter eat before a race?", Punch="Nothing, they fast!"},
                new Joke {Category = "General", Setup="What has more letters than the alphabet?", Punch="The post office!"},
                new Joke {Category = "Knock-Knock", Setup="Knock knock. Who's there? Europe. Europe who?", Punch="No, you're a poo!"},
                new Joke {Category = "Wife", Setup="My wife gets angry…", Punch="That I keep introducing her as my ex-girlfriend."},
                new Joke {Category = "Sports", Setup="What kind of shoes do ninjas wear?", Punch="Sneakers!"},
                new Joke {Category = "General", Setup="How did Harry Potter get down the hill?", Punch="Walking. JK! Rowling."},
            };

                _context.AddRange(jokes);
                _context.SaveChanges();

                return ("Seeding Done!");
            }
            return ("The database is not empty");
        }

        //Get random Joke by type
        [HttpGet("bytype")]
        public async Task<ActionResult<Joke>> GetJokebyType(string type)
        {
            if (_context.Jokes == null)
            {
                return NotFound();
            }
            List<Joke> jokes = await _context.Jokes.Where(j => j.Category == type).ToListAsync();
            
            if (jokes == null)
            {
                return NotFound();
            }
            var random = new Random();
            var index = random.Next(jokes.Count);
            var randomJoke = jokes[index];

            return Ok(randomJoke);
        }
        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
            if (id != joke.Id)
            {
                return BadRequest();
            }

            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
          if (_context.Jokes == null)
          {
              return Problem("Stop joking... Please fill the joke content");
          }
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            if (_context.Jokes == null)
            {
                return NotFound();
            }
            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Get random Jokes
        [HttpGet("random")]
        public async Task<ActionResult<Joke>> random()
        {
            List<Joke> jokes = await _context.Jokes.ToListAsync();

            var random = new Random();
            int index = random.Next(jokes.Count);
            return Ok(jokes[index]);   
        }

        //Get joke Categories or Types
        [HttpGet("types")]
        public async Task<ActionResult<Joke>> type()
        {
            List<Joke> types = await _context.Jokes.ToListAsync();

            return Ok(types.Select(t => t.Category).Distinct());
        }

        private bool JokeExists(int id)
        {
            return (_context.Jokes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DadJokesAPI.Models;

namespace DadJokesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly JokeDbContext _context;

        public JokesController(JokeDbContext context)
        {
            _context = context;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            return await _context.Jokes.ToListAsync();
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
          if (_context.Jokes == null)
          {
              return NotFound();
          }
            var joke = await _context.Jokes.FindAsync(id);

            if (joke == null)
            {
                return NotFound();
            }

            return joke;
        }

        //Seed Method
        [HttpGet("seed")]
        public string Seed()
        {
            if (!_context.Jokes.Any())
            {
                List<Joke> jokes = new List<Joke>
            {
                new Joke {Category = "General", Setup="I don't trust those trees", Punch="They seem kind of shady."},
                new Joke {Category = "Wife", Setup="My wife is really mad at the fact that I have no sense of direction", Punch="So I packed up my stuff and right!"},
                new Joke {Category = "Sports", Setup="Why couldn't the bicycle stand up by itself?", Punch="It was two tired."},
                new Joke {Category = "General", Setup="What did the ocean say to the beach?", Punch="Nothing, it just waved."},
                new Joke {Category = "Knok-Knock", Setup="Knock knock. Who's there? Spell. Spell who?", Punch="Okay, fine. W-H-O!"},
                new Joke {Category = "Wife", Setup="My wife said I should do lunges to stay in shape.", Punch="That would be a big step forward."},
                new Joke {Category = "Knok-Knock", Setup="nock knock. Who's there? I am. I am who? ", Punch="I am who is knocking. Who are you?"},
                new Joke {Category = "Sports", Setup="What does a sprinter eat before a race?", Punch="Nothing, they fast!"},
                new Joke {Category = "General", Setup="What has more letters than the alphabet?", Punch="The post office!"},
                new Joke {Category = "Knock-Knock", Setup="Knock knock. Who's there? Europe. Europe who?", Punch="No, you're a poo!"},
                new Joke {Category = "Wife", Setup="My wife gets angry…", Punch="That I keep introducing her as my ex-girlfriend."},
                new Joke {Category = "Sports", Setup="What kind of shoes do ninjas wear?", Punch="Sneakers!"},
                new Joke {Category = "General", Setup="How did Harry Potter get down the hill?", Punch="Walking. JK! Rowling."},
            };

                _context.AddRange(jokes);
                _context.SaveChanges();

                return ("Seeding Done!");
            }
            return ("The database is not empty");
        }
        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
            if (id != joke.Id)
            {
                return BadRequest();
            }

            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
          if (_context.Jokes == null)
          {
              return Problem("Stop joking... Please fill the joke content");
          }
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            if (_context.Jokes == null)
            {
                return NotFound();
            }
            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("random")]
        public async Task<ActionResult<Joke>> random()
        {
            List<Joke> jokes = await _context.Jokes.ToListAsync();

            var random = new Random();
            int index = random.Next(jokes.Count);
            return Ok(jokes[index]);
            
            
        }
        private bool JokeExists(int id)
        {
            return (_context.Jokes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

                return NotFound();
            }

            return joke;
        }

        //Seed Method
        [HttpGet("seed")]
        public string Seed()
        {
            if (!_context.Jokes.Any())
            {
                List<Joke> jokes = new List<Joke>
            {
                new Joke {Category = "General", Setup="I don't trust those trees", Punch="They seem kind of shady."},
                new Joke {Category = "Wife", Setup="My wife is really mad at the fact that I have no sense of direction", Punch="So I packed up my stuff and right!"},
                new Joke {Category = "Sports", Setup="Why couldn't the bicycle stand up by itself?", Punch="It was two tired."},
                new Joke {Category = "General", Setup="What did the ocean say to the beach?", Punch="Nothing, it just waved."},
                new Joke {Category = "Knok-Knock", Setup="Knock knock. Who's there? Spell. Spell who?", Punch="Okay, fine. W-H-O!"},
                new Joke {Category = "Wife", Setup="My wife said I should do lunges to stay in shape.", Punch="That would be a big step forward."},
                new Joke {Category = "Knok-Knock", Setup="nock knock. Who's there? I am. I am who? ", Punch="I am who is knocking. Who are you?"},
                new Joke {Category = "Sports", Setup="What does a sprinter eat before a race?", Punch="Nothing, they fast!"},
                new Joke {Category = "General", Setup="What has more letters than the alphabet?", Punch="The post office!"},
                new Joke {Category = "Knock-Knock", Setup="Knock knock. Who's there? Europe. Europe who?", Punch="No, you're a poo!"},
                new Joke {Category = "Wife", Setup="My wife gets angry…", Punch="That I keep introducing her as my ex-girlfriend."},
                new Joke {Category = "Sports", Setup="What kind of shoes do ninjas wear?", Punch="Sneakers!"},
                new Joke {Category = "General", Setup="How did Harry Potter get down the hill?", Punch="Walking. JK! Rowling."},
            };

                _context.AddRange(jokes);
                _context.SaveChanges();

                return ("Seeding Done!");
            }
            return ("The database is not empty");
        }
        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, Joke joke)
        {
            if (id != joke.Id)
            {
                return BadRequest();
            }

            _context.Entry(joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(id))
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

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joke>> PostJoke(Joke joke)
        {
          if (_context.Jokes == null)
          {
              return Problem("Entity set 'JokeDbContext.Jokes'  is null.");
          }
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            if (_context.Jokes == null)
            {
                return NotFound();
            }
            var joke = await _context.Jokes.FindAsync(id);
            if (joke == null)
            {
                return NotFound();
            }

            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JokeExists(int id)
        {
            return (_context.Jokes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

