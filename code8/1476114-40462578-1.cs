    HttpMultipartFormDataContent form = new HttpMultipartFormDataContent();
    using (IInputStream fileStream = await file.OpenSequentialReadAsync())
    {
        HttpStreamContent streamContent = new HttpStreamContent(fileStream);
        form.Add(streamContent, "file", file.Name);
        using (HttpClient client = new HttpClient())
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("http://127.0.0.1:9096/hello.php")))
            {
                request.Content = form;
                HttpResponseMessage response = await client.SendRequestAsync(request);
                Debug.WriteLine("\nRequest: " + request.ToString());
                Debug.WriteLine("\n\nResponse: " + response.ToString());
            }
        }
    }
