    string token = "";
    using (var client = new HttpClient())
    {
        
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        using (var content = new MultipartFormDataContent("MyPartBoundary198374"))
        {
            var stringContent = new StringContent("<h1>Hello</h1>",Encoding.UTF8, "text/html");
            content.Add(stringContent, "Presentation");
            using (
               var message =
                   await client.PostAsync("https://graph.microsoft.com/v1.0/me/onenote/sections/{id}/pages", content))
            {
                Console.WriteLine(message.StatusCode);
            }
        }
    }
