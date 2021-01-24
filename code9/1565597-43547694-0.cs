    public async Task<XmlDocument> GetQuotationAsync(QuotationRequest quotationRequest)
    {
        ...
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(restResponse.Content);  
        return xmlDoc;
    }
