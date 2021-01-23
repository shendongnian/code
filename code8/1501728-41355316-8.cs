    public class AuthorizationController : Controller
    {
        // Warning: extreme caution must be taken to ensure the authorization endpoint is not included in a CORS policy
        // that would allow an attacker to force a victim to silently authenticate with his Windows credentials
        // and retrieve an access token using a cross-domain AJAX call. Avoiding CORS is strongly recommended.
        [HttpGet("~/connect/authorize")]
        public async Task<IActionResult> Authorize(OpenIdConnectRequest request)
        {
            // Retrieve the Windows principal: if a null value is returned, apply an HTTP challenge
            // to allow IIS/WebListener to initiate the unmanaged integrated authentication dance.
            var principal = await HttpContext.Authentication.AuthenticateAsync(IISDefaults.Negotiate);
            if (principal == null)
            {
                return Challenge(IISDefaults.Negotiate);
            }
        
            // Note: while the principal is always a WindowsPrincipal object when using Kestrel behind IIS,
            // a WindowsPrincipal instance must be manually created from the WindowsIdentity with WebListener.
            var ticket = CreateTicket(request, principal as WindowsPrincipal ?? new WindowsPrincipal((WindowsIdentity) principal.Identity));
            // Immediately return an authorization response without displaying a consent screen.
            return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
        }
        private AuthenticationTicket CreateTicket(OpenIdConnectRequest request, WindowsPrincipal principal)
        {
            // Create a new ClaimsIdentity containing the claims that
            // will be used to create an id_token, a token or a code.
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
        
            // Note: the JWT/OIDC "sub" claim is required by OpenIddict
            // but is not automatically added to the Windows principal, so
            // the primary security identifier is used as a fallback value.
            identity.AddClaim(OpenIdConnectConstants.Claims.Subject, principal.GetClaim(ClaimTypes.PrimarySid));
        
            // Note: by default, claims are NOT automatically included in the access and identity tokens.
            // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
            // whether they should be included in access tokens, in identity tokens or in both.
        
            foreach (var claim in principal.Claims)
            {
                // In this sample, every claim is serialized in both the access and the identity tokens.
                // In a real world application, you'd probably want to exclude confidential claims
                // or apply a claims policy based on the scopes requested by the client application.
                claim.SetDestinations(OpenIdConnectConstants.Destinations.AccessToken,
                                      OpenIdConnectConstants.Destinations.IdentityToken);
        
                // Copy the claim from the Windows principal to the new identity.
                identity.AddClaim(claim);
            }
        
            // Create a new authentication ticket holding the user identity.
            return new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                OpenIdConnectServerDefaults.AuthenticationScheme);
        }
    }
