    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Jwt;
    using Owin;
    
    [assembly: OwinStartup(typeof(WebApplication1.Startup))]
    namespace WebApplication1
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var issuer = "test";
                var audience = issuer;
                var key = new AesManaged().Key;
    
                var options = new JwtBearerAuthenticationOptions
                {
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new[] { new SymmetricKeyIssuerSecurityTokenProvider(issuer, key) }
                };
                app.UseJwtBearerAuthentication(options);
    
                app.Map("/Login", subApp =>
                {
                    subApp.Run(context =>
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Sha256Digest),
                            Audience = audience,
                            Issuer = issuer,
                            Subject = new ClaimsIdentity(new[]
                            {
                              new Claim(ClaimTypes.Name, "Serge")
                            })
                        };
                        var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    
                        return context.Response.WriteAsync(token);
                    });
                });
            }
        }
    }
