    public class AwesomeAuthentication : AuthenticationHandler<AwesomeAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var prop = new AuthenticationProperties();
            var ticket = new AuthenticationTicket(Context.User, prop, "AwesomeAuthentication");
            //this is where you setup the ClaimsPrincipal
            //if auth fails, return AuthenticateResult.Fail("reason for failure");
            return await Task.Run(() => AuthenticateResult.Success(ticket));
        }
    }
