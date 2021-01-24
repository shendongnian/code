    public static HttpContent DoPost(object payload, string subPath)
        {
            var httpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(Global.BaseUrl);
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // if you're using json service
            // make request
            var response = Global.HttpClient.PostAsJsonAsync(subPath.TrimLeadingSlash(), payload).Result;
            // check for error
            response.EnsureSuccessStatusCode();
            // return result
            return response.Content;
        }
