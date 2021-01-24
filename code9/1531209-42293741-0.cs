        public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
        {
            protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
            {
                // Implement logic suitable for your case           
                return new ClaimsPrincipal(identity);
            }
        }
