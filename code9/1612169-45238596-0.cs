    static void Main(string[] args)
    {
      Task<string> task = GetCustomerDetails(); //PushCustomerDetails();
       var x = task.Result; //Result is already waiting
    }
    static Task<string> GetCustomerDetails()
    {
       var httpClientHandler = new HttpClientHandler()
       {
          Credentials=new NetworkCredential("demo","demo"),
       };
       var httpClient = new HttpClient(httpClientHandler);
       httpClient.DefaultRequestHeaders.Accept.Clear();
   
       httpClient.DefaultRequestHeaders.Accept.Add(new      
    MediaTypeWithQualityHeaderValue("application/json"));
       return httpClient.GetStringAsync("URL")
    }     
