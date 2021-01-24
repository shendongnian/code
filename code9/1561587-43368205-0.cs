    using (HttpClient client = new HttpClient())
    {
        using (HttpResponseMessage response = client.GetAsync(url).Result)
        {
            using (HttpContent content = response.Content)
            {
                string result = content.ReadAsStringAsync().Result;
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(result);
                var nodes = document.DocumentNode.SelectNodes("Your nodes");
                Some work with page....
            }
        }
    }
