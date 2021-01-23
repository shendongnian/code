        private static bool ValidateToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null)
                return false;
            if (!identity.IsAuthenticated)
                return false;
            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;
            if (string.IsNullOrEmpty(username))
                return false;
            // More validate to check whether username exists in system
            return true;
        }
        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string username;
            if (ValidateToken(token, out username))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    // Add more claims if needed: Roles, ...
                };
                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);
        }
