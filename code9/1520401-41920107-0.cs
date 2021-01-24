    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
    {
      // Rest of config left out for brevity
      Notifications = new OpenIdConnectAuthenticationNotifications
      {
        SecurityTokenValidated = async (notification) =>
        {
          ClaimsIdentity identity = notification.AuthenticationTicket.Identity;
          //Get the user data any way you want
          //Add claims
          identity.AddClaim(new Claim("homeTown", "Somewhere"));
        }
      }
    });
