    ConcurrentQueue<(string token, QuoteDetails details)> _productDetails;
    
    public SaverService(StatelessServiceContext context)
        : base(context)
    {
        _productDetails = new ConcurrentQueue<(string, QuoteDetails)>();
    }
    
    // this function will be fired and forgotten by the external service
    public async Task SaveRecentRequest(RequestOptions requestData, Response responseData)
    {
        await Task.Run(() => {
            foreach (var token in requestData.ProductAccessTokens)
            {
                // this function will extract the specific product request ( one request can contain multiple products )
                var details = SplitQuoteByProduct(requestData, responseData, token);
                _productDetails.Enqueue((token, details));
            }
        });
    }
    
    // this function will be executed by a timer every N amount of time
    public void SaveRequestsToDatabase()
    {
        var products = new List<(string token, QuoteDetails details)>();
    
        (string token, QuoteDetails details) item;
    
        while (_productDetails.TryDequeue(out item))
        {
            products.Add(item);
        }
    
        foreach (var group in products.GroupBy(i => i.token))
        {
            SaveProductRequests(group.Key, group);
        }
    }
    
    public async Task SaveProductRequests(string productId, IEnumerable<QuoteDetails> productRequests)
    {
        // save received items to database
        /// ...
    }
