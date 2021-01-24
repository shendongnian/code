    public void HandlerMethod(object obj)
    {
        var line = (string)obj;
        var result = string.Empty;
        using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
        {
            client.BaseAddress = new Uri("https://www.website.com/");
            HttpResponseMessage response = client.GetAsync("index?userGetLevel=" + line).Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic json = JObject.Parse(result);
            result = json.data.level;
        }
        //for the first way
        if (string.IsNullOrWhiteSpace(result))
        {
            messages.Enqueue("{0}: User does not exist.", line);
        }
        else
        {
            messages.Enqueue("{0}: User level is {1}.", line, result);
        }
        //for the second way
        //lock(lockObj)
        //{
        //    using (StreamWriter sw = File.AppendText(levels.txt))
        //    {
        //        sw.WriteLine("{0} : {1}", line, level);
        //    }
        //}
    }
