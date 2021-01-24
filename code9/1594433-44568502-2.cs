    namespace YourNameSpace {
 
     public class MultiCredentialProvider : ICredentialProvider
        {
           public Dictionary<string, string> Credentials = new Dictionary<string, string>
        {
            { MicrosoftAppID1, MicrosoftAppPassword1},
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
