    var uri = // get uri from form;
    var formVariables = new List<KeyValuePair<string, string>>();
    // Populate your variables here; HtmlAgilityPack is useful for propagating existing form values
    formVariables.Add(new KeyValuePair<string,string>("id","t2"));
    var formContent = new FormUrlEncodedContent(formVariables);
    using (var message = new HttpRequestMessage { Method = HttpMethod.Post, RequestUri = uri, Content = formContent })
    {
        // use HttpClient to send the message
        using (var postResponse = await client.SendAsync(message))
        {
            if (postResponse.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                // Do something with string content
            }
        }
    }
                                        
