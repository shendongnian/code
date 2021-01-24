    public class ClientHandler
    {
       private HttpClient _client;
      
       public ClientHander()
       {
            // add handler if needed ex var handler = new HttpClientHandler()
            
            _client = new HttpClient(/*handler*/);
            
            // add default header if needed client.DefaultRequestHeaders
       }
       public HttpResponseMessage Post(string path, HttpContent content)
       {
          // You can async if you want
          return _client.Post(path, content).Result;
       }
    }
