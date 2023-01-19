using Microsoft.EntityFrameworkCore;

namespace DadJokesAPI.Models
{
    public class JokeDbContext : DbContext 
    {
        public JokeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Joke> Jokes { get; set; }
    }
}
