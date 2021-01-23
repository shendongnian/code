public class AzureADAuthorize : AuthorizeAttribute
    {
        public AzureADAuthorize() : base(AzureADPolicies.Name)
        {
        }
    }
AzureADPolicies.cs:
public static class AzureADPolicies
    {
        public static string Name => "AzureADAuthorizationRequired";
        public static void Build(AuthorizationPolicyBuilder builder)
            {
                if (StaticRepo.Configuration.GetValue<bool>("EnableAuthorization") == true)
                {
                    var section = StaticRepo.Configuration.GetSection($"AzureAd:AuthorizedAdGroups");
                    var groups = section.Get<string[]>();
                    builder.RequireClaim("groups", groups);
                }
                else if (StaticRepo.Configuration.GetValue<bool>("EnableAuthentication") == true)
                {
                    builder.RequireAuthenticatedUser();
                }else
                {
                    builder
                    .RequireAssertion(_ => true)
                    .Build();
                }             
            }
    }
Startup.cs:
//Authentication & Authorization
            #region AUTHENTICATION / AUTHORICATION
            StaticRepo.Configuration = Configuration;
            
            
                services.AddAuthorization(options =>
                {
                    options.AddPolicy(
                        AzureADPolicies.Name, AzureADPolicies.Build);
                });
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
             .AddAzureAD(options => Configuration.Bind("AzureAd", options));
            #endregion
Appsettings.json:
 "EnableAuditLogging": false,
  "EnableAuthentication": true,
  "EnableAuthorization": false,
"AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "https://MyDomain.onmicrosoft.com/",
    "TenantId": "b6909603-e5a8-497d-8fdb-7f10240fdd10",
    "ClientId": "6d09a1bf-4678-4aee-b67c-2d6df68d5324",
    "CallbackPath": "/signin-oidc",
    //Your Azure AD Security Group Object IDs that users needs to be member of to gain access
    "AuthorizedAdGroups": [
      "568bd325-283f-4909-9fcc-a493d19f98e8",
      "eee6d366-0f4d-4fca-9965-b2bc0770506d"
    ]
  }
(These are random guids)
Now you can conditional control if you want to have anonymous access, azure ad authentication,  authentication + group authorization. There are still some stuff you need to setup in your azure ad app manifest file to get it to work, but I think it's outside the scope here.
