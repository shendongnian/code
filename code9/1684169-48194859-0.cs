    public class OptionsProvider : IOptions<IdentityOptions>
    {
        public IdentityOptions Value { get
            {
                var result = new IdentityOptions();
                result.ClaimsIdentity = new ClaimsIdentityOptions { UserIdClaimType = "sub" };
                return result;
            }
        }
    }
