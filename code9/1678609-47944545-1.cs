    public static async Task<string> PostRequestAsync(string URI, string PostParams) {            
        var response = await client.PostAsync(URI, new StringContent(PostParams));
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
