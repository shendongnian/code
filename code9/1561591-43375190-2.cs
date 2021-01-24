    // instance or static variable
    HttpClient client = new HttpClient();
    // get answer in non-blocking way
    using (var response = await client.GetAsync(url))
    {
        using (var content = response.Content)
        {
            // read answer in non-blocking way
            var result = await content.ReadAsStringAsync();
            var document = new HtmlDocument();
            document.LoadHtml(result);
            var nodes = document.DocumentNode.SelectNodes("Your nodes");
            //Some work with page....
        }
    }
