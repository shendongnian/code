    class Program
    {
        private static HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            GetStreamsAsync();
            Console.ReadKey();
        }
        static async void GetStreamsAsync()
        {
            try
            {
                using (var t1 = await _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt").ConfigureAwait(false))
                {
                    Console.WriteLine("complete");
                }
                using (var t2 = await _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt").ConfigureAwait(false))
                {
                    Console.WriteLine("complete");
                }
                using (var t3 = await _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt").ConfigureAwait(false))
                {
                    Console.WriteLine("complete");
                }
                using (var t4 = await _client.GetStreamAsync("http://www.w3.org/TR/PNG/iso_8859-1.txt").ConfigureAwait(false))
                {
                    Console.WriteLine("complete");
                }
            }
            catch (System.Exception ex)
            {
            }
        }
    }
