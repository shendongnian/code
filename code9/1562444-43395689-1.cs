    class Program
    {
        static void Main(string[] args) => Task.Run(() => MainAsync(args)).Wait();
    
        static async Task MainAsync(string[] args)
        {
            var html = await GetResponseFromURI(new Uri("http://www.dailymail.co.uk/sciencetech/article-4408856/Samsung-building-flip-phone-TWO-screens.html?ITO=1490&ns_mchannel=rss&ns_campaign=1490"));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//div[@itemprop=\"articleBody\"]");
            if (nodes != null)
            {
                Console.WriteLine(nodes.Select(node => node.InnerText).FirstOrDefault());
            }
            Console.ReadLine();
        }
    
        static async Task<string> GetResponseFromURI(Uri uri)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(uri);
                if (result.IsSuccessStatusCode)
                    response = await result.Content.ReadAsStringAsync();
            }
            return response;
        }
    }
