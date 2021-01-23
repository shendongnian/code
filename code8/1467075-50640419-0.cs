                options.Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = (context) =>
                    {
                        var claims = new List<Claim>();
                        foreach (var claim in context.Principal.Claims)
                        {
                            if (claim.Type == ClaimTypes.Role) claims.Add(new Claim(ClaimTypes.Role, claim.Value));
                        }
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        context.Principal.AddIdentity(claimsIdentity);
                        return Task.CompletedTask;
                    }
                };
