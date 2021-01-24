    filename = "filename from previous insert";
    inUrl = "domain.com/ui/checksums/fix";
    var stringPayload = "{\"repoKey\":\"repoKey\",\"path\":\"" + filename + "\"}";
    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
    
    var resp = client.PostAsync(inUrl, httpContent);
    
    using (HttpContent content = resp.Result.Content)
    {
        string result = content.ReadAsStringAsync().Result;
    }
