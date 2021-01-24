    public async Task<ActionResult> TestSSN()
    {
        //...
        var apiResponse = await GetUsTraceApiHealth();
        string responseBody = await apiResponse.Content.ReadAsStringAsync();
        //...
    }
