    public async Task<HttpResponseMessage> GetQuotationAsync(QuotationRequest quotationRequest)
    {
        ...
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(restResponse.Content);  
        string jsonText = JsonConvert.SerializeObject(xmlDoc, Newtonsoft.Json.Formatting.Indented);
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(jsonText, System.Text.Encoding.UTF8, "application/json");
        return response;
    }
