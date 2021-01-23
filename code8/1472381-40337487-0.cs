       static void Main(string[] args)
        {
            GetStuff();
            Console.ReadLine();
        }
        private static async void GetStuff()
        {
            CancellationToken ct = new CancellationToken();
            var client = new HttpClient();
            //this is only a Simple Change to demonstrate the problem, and should not be considered as a proper solution
            string url = "https://scontent.xx.fbcdn.net/v/t1.0-1/c15.0.50.50/p50x50/10354686_10150004552801856_220367501106153455_n.jpg?oh=6c801f82cd5a32fd6e5a4258ce00a314&oe=589AAD2F";
            if (url == null) return;
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, sdch, br");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
            var response = await client.GetAsync(url, ct);
            ct.ThrowIfCancellationRequested();
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var stream = await response.Content.ReadAsStreamAsync();
                    break;
                default:
                    break;
            }
        }
