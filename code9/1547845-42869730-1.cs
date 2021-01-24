    public interface IRequests
    {
        string GetFromUri(string fullUri);
    }
    
    public class Requests : IRequests
    {
        public string GetFromUri(string fullUri)
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                Credentials = Settings.ServiceCredential
            };
    
            using (HttpClient client = new HttpClient(handler))
            {
                return client.GetStringAsync(fullUri).Result;
            }
        }
    }
