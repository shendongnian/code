    public async Task<Stream> GetPDF(string docPath) {
        if (String.IsNullOrWhiteSpace(docPath))
            return null;
    
        docPath = HttpUtility.UrlDecode(docPath.Replace('~', '%'));
    
        if (docPath.Contains(".."))
            return null;
    
        var url = ServiceUrl + "api/Document/PDF?docPath=" + docPath;
    
        using (var response = await client.GetAsync(url)) {
            return await response.Content.ReadAsStreamAsync();            
        }
    }
