    app.Use(async (context, next) =>
            {
                var authHeader = context.Request.Headers["Authorization"].ToString();
                if (authHeader != null && authHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                {
                    var tokenStr = authHeader.Substring("Bearer ".Length).Trim();
                    System.Console.WriteLine(tokenStr);
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadToken(tokenStr) as JwtSecurityToken;
                    var nameid = token.Claims.First(claim => claim.Type == "nameid").Value;
                    var identity = new ClaimsIdentity(token.Claims);
                    context.User = new ClaimsPrincipal(identity);
                }
                await next();
            });
