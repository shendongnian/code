    public async static Task<string> ConvertFiles(string s1, string s2, string webAddress)
    {
        using(HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Cleare();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    
            List<KeyValuePair<string,string>> formFields = new List<KeyValuePair<string,string>>();
            formFields.Add(new KeyValuePair<string,string>("s1", s1));
            formFields.Add(new KeyValuePair<string,string>("s2", s2));
            var formContent = new FormUrlEncodedContent(formFields);
    
            HttpResponseMessage response = await client.PostAsync(webAddress, formContent);
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Result: " + content);
            return content;
        }
    }
    [HttpPost("/mshdf/import")]
    public string ConvertFiles(FormDataCollection data)
    {
        Console.WriteLine(data.Get("s1"));
        Console.WriteLine(data.Get("s2"));
        return "woo";
    }
