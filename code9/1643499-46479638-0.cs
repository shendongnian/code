    static async Task<int> Main()
    {
        string urlAddress = "mywebsite";
    
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(urlAddress);
    
            // Post link
            var post = doc.GetElementbyId("post").GetAttributeValue("href", "");
    
            doc = web.Load(post);
    
            // get the form
            var form = doc.DocumentNode.SelectSingleNode("//form[@class='picker']");
    
            // get the form URI
            string actionValue = form.Attributes["action"]?.Value;
            System.Uri uri = new System.Uri(actionValue);
    
            // Populate the form variable
            var formVariables = new List<KeyValuePair<string, string>>();
            formVariables.Add(new KeyValuePair<string, string>("id", "ho"));
            var formContent = new FormUrlEncodedContent(formVariables);
    
            // submit the form
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, formContent);
    }
