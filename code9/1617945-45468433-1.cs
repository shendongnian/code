    public async Task<IssueListModelView> FetchIssues(string token, string type) {
        client.BaseAddress = new Uri(XTMonitorContants.SERVICE_BASE_URL);
        var uri = new Uri(XTMonitorContants.SERVICE_ISSUES_URL + type.ToLower());
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.Headers.Authorization = new AuthenticationHeaderValue("Token", token);
        
        var response = await client.SendAsync(request);
        var jsonString = await response.Content.ReadAsStringAsync();
        IssueListModelView resp = new IssueListModelView();
        if (jsonString != "") {
            try {
                resp = JsonConvert.DeserializeObject<IssueListModelView>(jsonString);
            } catch (Exception) {
                resp.error = "Internal Server Error";
            }
        }
        return resp;
    }
