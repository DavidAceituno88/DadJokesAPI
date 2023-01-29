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
