        [AttributeUsage(AttributeTargets.All)]
        public sealed class ClaimAuthorizationAttribute : AuthorizeAttribute
        {
            /// <summary>
            /// Gets or sets the claim to check in the web token
            /// </summary>
            public string Claim { get; set; }
    
            /// <inheritdoc/>
            protected override bool IsAuthorized(HttpActionContext actionContext)
            {
                if (actionContext == null)
                {
                    throw new ArgumentNullException(nameof(actionContext));
                }
    
                var decoder = new JwtSecurityTokenHandler();
    
                var token = (JwtSecurityToken)decoder.ReadToken(actionContext.Request.Headers.Authorization.Parameter);
    
                return token.Claims.Any(c => c.Type.Equals(this.Claim) && c.Value.Equals("True", StringComparison.OrdinalIgnoreCase));
            }
        }
