    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
    /*                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 var response = client.GetAsync(baseAddress + "api/values").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);*/
                Console.ReadLine();
            }
        }
    }
