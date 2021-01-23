    public class YourApp
    {
        private static HttpClient Client = new HttpClient();
        public static void Main(string[] args)
        {
            Console.WriteLine("Requests about to start!");
            for(int i = 0; i < 5; i++)
            {
                var result = Client.GetAsync("http://www.stackoverflow.com").Result;
                Console.WriteLine(result);
            }
            Console.WriteLine("Requests are finished!");
            Console.ReadLine();
        }
    }
