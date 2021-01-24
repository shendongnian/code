    using Microsoft.IdentityModel.Protocols;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;
    public class ValidationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;
        private readonly Func<string> tokenAccessor;
        private readonly ConfigurationManager<OpenIdConnectConfiguration> configurationManager;
        private readonly Object locker = new Object();
        private Dictionary<string, SecurityKey> securityKeys = new Dictionary<string, SecurityKey>();
        public ValidationMiddleware(Func<IDictionary<string, object>, Task> next, Func<string> tokenAccessor)
        {
            this.next = next;
            this.tokenAccessor = tokenAccessor;
            configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                "url to open id connect token service", 
                new HttpClient(new WebRequestHandler()))
            {
                // Refresh the keys once an hour
                AutomaticRefreshInterval = new TimeSpan(1, 0, 0)
            };
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var token = tokenAccessor();
            var validationParameters = new TokenValidationParameters
            {
                ValidAudience = "my valid audience",
                ValidIssuer = "url to open id connect token service",
                ValidateLifetime = true,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                IssuerSigningKeyResolver = MySigningKeyResolver, // Key resolver gets called for every token
            };
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            var tokenHandler = new JwtSecurityTokenHandler(); 
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            // Assign Claims Principal to the context.
            await next.Invoke(environment);
        }
 
        private SecurityKey MySigningKeyResolver(string token, SecurityToken securityToken, SecurityKeyIdentifier keyIdentifier, TokenValidationParameters validationParameters)
        {
            var kid = keyIdentifier.OfType<NamedKeySecurityKeyIdentifierClause>().FirstOrDefault().Id;
            if (!securityKeys.TryGetValue(kid, out SecurityKey securityKey))
            {
                lock (locker)
                {
                    // Double lock check to ensure that only the first thread to hit the lock gets the latest keys.
                    if (!securityKeys.TryGetValue(kid, out securityKey))
                    {
                        // TODO - Add throttling around this so that an attacker can't force tonnes of page requests.
                        // Microsoft's Async Helper
                        var result = AsyncHelper.RunSync(async () => await configurationManager.GetConfigurationAsync());
                        var latestSecurityKeys = new Dictionary<string, SecurityKey>();
                        foreach (var key in result.JsonWebKeySet.Keys)
                        {
                            var rsa = RSA.Create();
                            rsa.ImportParameters(new RSAParameters
                            {
                                Exponent = Base64UrlEncoder.DecodeBytes(key.E),
                                Modulus = Base64UrlEncoder.DecodeBytes(key.N),
                            });
                            latestSecurityKeys.Add(key.Kid, new RsaSecurityKey(rsa));
                            if (kid == key.Kid)
                            {
                                securityKey = new RsaSecurityKey(rsa);
                            }
                        }
                        // Explicitly state that this assignment needs to be atomic.
                        Interlocked.Exchange(ref securityKeys, latestSecurityKeys);
                    }
                }
            }
            return securityKey;
        }
    }
