    public Task<HttpResponseMessage> GetOrder(string url) {
        xml = "<result><success> True </success><message></result>";
    
        var responseMessage = new  HttpResponseMessage() {
            Content = new StringContent(xml, Encoding.UTF8, "application/xml")
        }; 
        return Task.FromResult(responseMessage);   
    }
