    `[HttpPost]
    public async Task<string> PostSomething()
    {
        string result = await Request.Content.ReadAsStringAsync();
        //parse here how you want
        return result;
    }`
