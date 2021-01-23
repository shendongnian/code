    public async static Task<string> ConvertFiles(string s1, string s2, string webAddress)
    {
        Dictionary<string, string> jsonValues = new Dictionary<string, string>();
        jsonValues.Add("string1", "anyStringValue1");
        jsonValues.Add("string2", "anyStringValue2");
    
        HttpClient client = new HttpClient();
        StringContent sc = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(webAddress, sc);
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Result: " + content);
        return content;
    }
