    public class AzureAdOptions : OAuthOptions
    {
    
        public string Instance { get; set; }
    
        public string Resource { get; set; }
    
        public string TenantId { get; set; }
    
        public AzureAdOptions()
        {
            CallbackPath = new PathString("/signin-azureAd");
            AuthorizationEndpoint = AzureAdDefaults.AuthorizationEndpoint;
            TokenEndpoint = AzureAdDefaults.TokenEndpoint;
            UserInformationEndpoint = AzureAdDefaults.UserInformationEndpoint;
            Resource = AzureAdDefaults.Resource;
            Scope.Add("user.read");
            
            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
            ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
            ClaimActions.MapJsonKey(ClaimTypes.MobilePhone, "mobilePhone");
            ClaimActions.MapCustomJson(ClaimTypes.Email, user => user.Value<string>("mail") ?? user.Value<string>("userPrincipalName"));       
        }
    }
    
    public static class AzureAdDefaults
    {
        public static readonly string DisplayName = "AzureAD";
        public static readonly string AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/authorize";
        public static readonly string TokenEndpoint = "https://login.microsoftonline.com/common/oauth2/token";
        public static readonly string Resource =  "https://graph.microsoft.com";
        public static readonly string UserInformationEndpoint =  "https://graph.microsoft.com/v1.0/me";
        public const string AuthenticationScheme = "AzureAD";
    }
