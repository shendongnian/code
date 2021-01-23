    public static void Main(string[] args)
    {
	    var s = new HTTPServer();
    	s.StartListener();
	
    	Task.Run(async () =>
        {
	    	var myObj = 8;
	
            DirectHandler dh = new DirectHandler();
            var resp = await dh.SendToPlayer(myObj);
            Console.WriteLine("Received: " + resp);
            Thread.Sleep(500);
            resp = await dh.SendToPlayer(myObj);
            Console.WriteLine("Received: " + resp);
        }).Wait();
    }
    public class HTTPServer
    {
        public void StartListener()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:8080/");
	    	listener.Start();
            listener.BeginGetContext(new AsyncCallback(OnRequestReceive), listener);
        }
        private void OnRequestReceive(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
            string responseString = "{'a': \"b\"}";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            listener.BeginGetContext(new AsyncCallback(OnRequestReceive), listener);
        }
    }
    public class DirectHandler
    {
        HttpClient httpClient;
        public async Task<string> SendToPlayer(object message)
	    {
	    	if (httpClient == null)
  	      	{
    	        httpClient = new HttpClient();
            	httpClient.BaseAddress = new Uri("http://localhost:8080");
    	    }
    	    HttpResponseMessage response = await httpClient.PostAsJsonAsync("", message).ConfigureAwait(false); 
    	    if (response.IsSuccessStatusCode)
    	    {
            	var result = await response.Content.ReadAsByteArrayAsync();
            	return System.Text.Encoding.Default.GetString(result);
    	    }
    	    else
    	    {
            	throw new HttpRequestException("Error code " + response.StatusCode + ", reason: " + response.ReasonPhrase);
    	    }
	    }
    }
