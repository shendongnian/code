    public class MyAccessTokenProvider : AuthenticationTokenProvider
    {
      public override void Create(AuthenticationTokenCreateContext context)
      {
         ...
         var claim = context.Ticket.Identity.FindFirst(ClaimTypes.UserData);
         if (claim != null)
         {
             context.Ticket.Identity.RemoveClaim(claim);
             context.Ticket.Identity.AddClaim(new Claim(ClaimTypes.UserData, "New Value"));
         }
         context.SetToken(context.SerializeTicket());
      }
      public override void Receive(AuthenticationTokenReceiveContext context)
      {
         context.DeserializeTicket(context.Token);
      }
    }
    public class MyRefreshTokenProvider : AuthenticationTokenProvider
    {
      public override void Create(AuthenticationTokenCreateContext context)
      {
         context.SetToken(context.SerializeTicket());
      }
      public override void Receive(AuthenticationTokenReceiveContext context)
      {
         context.DeserializeTicket(context.Token);
      }
    }
    app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
    {
       ...
       AccessTokenProvider = new MyAccessTokenProvider(),
       RefreshTokenProvider = new MyRefreshTokenProvider()
    });
