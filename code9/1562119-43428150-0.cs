    class Program
    {
        private static HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            try
            {
                using (var t1 = _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt"))
                {
                    t1.Wait();
                    Console.WriteLine("complete");
                }
                using (var t2 = _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt"))
                {
                    t2.Wait();
                    Console.WriteLine("complete");
                }
                using (var t3 = _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt"))
                {
                    t3.Wait();
                    Console.WriteLine("complete");
                }
                using (var t4 = _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt"))
                {
                    t4.Wait();
                    Console.WriteLine("complete");
                }
                Console.ReadKey();
            }
            catch (System.Exception ex)
            {
            }
        }
