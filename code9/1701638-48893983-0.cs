    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
  
          public void ConfigureServices(IServiceCollection services)
            {
    
      //new policy makes [Authorize (Policy = "Your custom Policy")] availible by claims This is what you put on controllers
                services.AddAuthorization((options) => {
                    options.AddPolicy("Your custom Policy", policybuilder =>
                    {               
                        policybuilder.RequireAuthenticatedUser();
                        policybuilder.RequireClaim("role", "PayingUserExampleProperty");
    
                    });
                });
