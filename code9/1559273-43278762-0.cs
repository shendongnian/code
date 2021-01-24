     static void Main(string[] args)
            {
                Console.ReadLine();
    
    
                WebClient wc = new WebClient();
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string json = wc.UploadString("http://localhost:49847/Home/Index", "k=1");
                    dynamic receivedData = JsonConvert.DeserializeObject(json);
                    Console.WriteLine("Result: {0};", receivedData.data);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh bother");
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                }
            }
