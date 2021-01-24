    class Program
        {
            static void Main(string[] args)
            {
                using (var client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("http://localhost:24932/api/values",
                        new List<int>() {123, 123, 123}).Result;
    
                    Console.ReadLine();
                }
            }
        }
