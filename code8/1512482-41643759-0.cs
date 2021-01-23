    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:44300/";
            using (WebApp.Start<Startup>(url))
            {
                var client = new HttpClient();
    
                var response = client.GetAsync(url + "api/myapi").Result;
    
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("WebApp Ready");
                Console.ReadLine();
            }
            Console.WriteLine("WebApp disposed.");
            Console.ReadLine();
        }
    }
