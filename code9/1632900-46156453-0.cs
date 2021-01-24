    public class TestHandlerOptions : AuthenticationSchemeOptions { }
    
    internal class TestHandler : AuthenticationHandler<TestHandlerOptions> {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            if (await SomeCheckAsync()) {
                var identity = new ClaimsIdentity(ClaimsName);
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), null, ClaimsName);
                return AuthenticateResult.Success(ticket);
            }
    
            return AuthenticateResult.Fail("Missing or malformed 'Authorization' header.");
        }
    }
