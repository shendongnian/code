    var response =  client.GetAsync("https://api.stackexchange.com/2.2/badges?order=desc&sort=rank&site=stackoverflow").Result;
    string res = "";
    using (HttpContent content = response.Content)
    {
       Task<string> result =  content.ReadAsStringAsync();
       res = result.Result;
    }
