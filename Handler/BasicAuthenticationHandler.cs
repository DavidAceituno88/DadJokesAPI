using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace DadJokesAPI.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock ): base(options,logger,encoder,clock)
        {

        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.Fail("");
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace DadJokesAPI.Models
{
    public class JokeDbContext : DbContext 
    {
        public JokeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Users> User { get; set; }
    }
}
