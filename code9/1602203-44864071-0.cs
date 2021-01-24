    volatile bool serverIsReady = false;
    //Holds List of all the headers from received from UnityWebRequest request
    List<HeaderInfo> headers = new List<HeaderInfo>();
    
    void Start()
    {
        StartCoroutine(getUnityWebRequestHeaders());
    }
    
    IEnumerator getUnityWebRequestHeaders()
    {
        //Start Http Server
        ThreadPool.QueueUserWorkItem(new WaitCallback(RunInNewThread), new string[] { "http://*:8080/" });
    
        //Wait for server to actually start
        while (!serverIsReady)
            yield return null;
    
        Debug.LogWarning("Server is ready");
    
        yield return new WaitForSeconds(0.2f);
    
    
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080", "");
        yield return www.Send();
    
        //Check if connections was successfull
        if (!www.isError && www.downloadHandler.text.Contains("SUCCESS"))
        {
            Debug.LogWarning("Connection was successfull");
        }
    
        //Show all the headers from UnityWebRequest
        for (int i = 0; i < headers.Count; i++)
        {
            Debug.Log("KEY: " + headers[i].header + "    -    VALUE: " + headers[i].value);
        }
    }
    
    private void RunInNewThread(object a)
    {
        //Cast parameter back to string array
        string[] serverPrefix = (string[])a;
        //Start server with the provided parameter
        SimpleListenerExample(serverPrefix);
    }
    
    //Creates a http server
    public void SimpleListenerExample(string[] prefixes)
    {
        serverIsReady = false;
    
        if (!HttpListener.IsSupported)
        {
            Debug.LogWarning("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
            return;
        }
        //URI prefixes are required,
        //for example "http://contoso.com:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
            throw new ArgumentException("prefixes");
    
        //Create a listener.
        HttpListener listener = new HttpListener();
        //Add the prefixes.
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        Debug.LogWarning("Listening...");
    
        serverIsReady = true;
    
        //Note: The GetContext method blocks while waiting for a request. 
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        //Obtain a response object.
        HttpListenerResponse response = context.Response;
        //Construct a response.
        string responseString = "<HTML><BODY>SUCCESS</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        //Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
    
        //Get all the headers sent from UnityWebRequest and add them to the List
        addHeaders(request);
    
        //You must close the output stream.
        output.Close();
        listener.Stop();
    }
    
    //Get all the headers sent from UnityWebRequest
    void addHeaders(HttpListenerRequest request)
    {
        System.Collections.Specialized.NameValueCollection receivedHeaders = request.Headers;
        for (int i = 0; i < receivedHeaders.Count; i++)
        {
            string key = receivedHeaders.GetKey(i);
            string value = receivedHeaders.Get(i);
            headers.Add(new HeaderInfo(key, value));
        }
    }
    
    //Hold header and value
    public class HeaderInfo
    {
        public string header;
        public string value;
    
        public HeaderInfo(string header, string value)
        {
            this.header = header;
            this.value = value;
        }
    }
