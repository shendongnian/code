    public static string PostRequest(string URI, string PostParams) {            
        var response = client.PostAsync(URI, new StringContent(PostParams)).GetAwaiter().GetResult();
        var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return content;
    }
