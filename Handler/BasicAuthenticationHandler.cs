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
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Azure.Core;
using DadJokesAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace DadJokesAPI.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly JokeDbContext _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, JokeDbContext context ): base(options,logger,encoder,clock)
        {
            _context = context;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No header fond");
            }

            var _headervalue = AuthenticationHeaderValue.Parse("Authorization");
            var bytes = Convert.FromBase64String(_headervalue.Parameter);
            string credentials = Encoding.UTF8.GetString(bytes);

            if(!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];

                var user = this._context.User.FirstOrDefault(item => item.Userid == username && item.Pass == password);

                if (user != null)
                {
                    return AuthenticateResult.Fail("Unauthorized");
                }

                //Generate ticket
                var claim = new[] { new Claim(ClaimTypes.Name,username) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }else
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

        }
    }
}
