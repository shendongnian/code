    namespace YourNameSpace {
      public class MultiCredentialProvider : ICredentialProvider
        {
           public Dictionary<string, string> Credentials = new Dictionary<string, string>
        {
    //you can store in your web config or somewhere else..
            { MicrosoftAppID1, MicrosoftAppPassword1
    },
            { MicrosoftAppID2, MicrosoftAppPassword2}
        };
        public Task<bool> IsValidAppIdAsync(string appId)
        {
            return Task.FromResult(this.Credentials.ContainsKey(appId));
        }
        public Task<string> GetAppPasswordAsync(string appId)
        {
            return Task.FromResult(this.Credentials.ContainsKey(appId) ? this.Credentials[appId] : null);
        }
        public Task<bool> IsAuthenticationDisabledAsync()
        {
            return Task.FromResult(!this.Credentials.Any());
        }
    }
  
     //here is your controller (Messages) and your custom BotAuthentication
        [BotAuthentication(CredentialProviderType = typeof(MultiCredentialProvider))]
        public class MessagesController : ApiController
    {
        static MessagesController()
        {
            // Update the container to use the right MicorosftAppCredentials based on
            // Identity set by BotAuthentication
            var builder = new ContainerBuilder();
            builder.Register(c => ((ClaimsIdentity)HttpContext.Current.User.Identity).GetCredentialsFromClaims())
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.Update(Conversation.Container);
        }
 
    [BotAuthentication(CredentialProviderType = typeof(MultiCredentialProvider))]
            public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
            {
                if (activity.Type == ActivityTypes.Message)
                {
    //handle your received message
                }
            }
    }
