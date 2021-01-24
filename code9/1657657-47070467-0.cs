    public class Program {
        static void Main(string[] args) {
            // this value is *already* 2 by default, set for visibility
            ServicePointManager.DefaultConnectionLimit = 2;
            // replace example.com with real site
            DoFttpRequest("http://example.com");
            DoFttpRequest("http://example.com");
            DoFttpRequest("http://example.com");
            Console.ReadLine();
        }
        private static HttpWebResponse DoFttpRequest(string uri) {
            var request = (HttpWebRequest) WebRequest.Create(uri);
            var response = (HttpWebResponse) request.GetResponse();
            Console.WriteLine("got response");
            return response;
        }
    }
