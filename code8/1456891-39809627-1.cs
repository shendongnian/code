    public class AwesomeAuthentication : AuthenticationHandler<AwesomeAuthenticationOptions>
    {
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var prop = new AuthenticationProperties();
            var ticket = new AuthenticationTicket(Context.User, prop, "AwesomeAuthentication");
            return Task.Run(() => AuthenticateResult.Success(ticket));
        }
    }
