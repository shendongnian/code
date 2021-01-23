    public class AwesomeAuthentication : AuthenticationHandler<AwesomeAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var prop = new AuthenticationProperties();
            var ticket = new AuthenticationTicket(Context.User, prop, "AwesomeAuthentication");
            return await Task.Run(() => AuthenticateResult.Success(ticket));
        }
    }
