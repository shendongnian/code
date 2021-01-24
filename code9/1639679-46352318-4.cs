    public async Task<OrderRequest> CreateOrder(OrderRequest orderRequest)
    {
        try
        {
            var asdf = OwinHttpRequestMessageExtensions.GetOwinContext(Request);
            if (!Request.Content.IsMimeMultipartContent("multipart/form-data"))
            {
                var provider = new MultipartMemoryStreamProvider();
                await this.Request.Content.ReadAsMultipartAsync(provider);
    
                var content = provider.Contents.First();
                var buffer = await content.ReadAsByteArrayAsync();
            }
    
            var test = orderRequest;
            var a = HttpContext.Current.Request.Files;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
        return null;
    }
