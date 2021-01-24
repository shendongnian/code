    private async Task<string> APIResponse()
    {
        using (HttpClient client = new HttpClient())
        {
            ...
            HttpResponseMessage response = await client.GetAsync("api/Values");
            ...
        }
    }
    protected async void Apibtn_Click(object sender, EventArgs e)
    {
        var apiResp = await APIResponse();
    }
