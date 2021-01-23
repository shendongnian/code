    public static string postTextAre(string text, string postUrl) {
        HttpClient httpClient = new HttpClient();
        MultipartFormDataContent form = new MultipartFormDataContent();
    
        form.Add(new StringContent(text), "Textbox1");
        form.Add(new StringContent("Save page"), "wpSave");
        HttpResponseMessage response = await httpClient.PostAsync(postUrl, form);
    
        response.EnsureSuccessStatusCode();
        httpClient.Dispose();
        return response.Content.ReadAsStringAsync().Result;
    }
