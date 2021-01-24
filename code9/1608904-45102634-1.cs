    // dictionary where key is ProductId and value is a list of items to insert to that product database
    Dictionary<string, List<QuoteDetails>> _productDetails;
    public SaverService(StatelessServiceContext context)
        : base(context)
    {
        _productDetails = new Dictionary<string, List<QuoteDetails>>();
    }
    // this function will be fired and forgotten by the external service
    public async Task SaveRecentRequest(RequestOptions requestData, Response responseData)
    {
        await Task.Run(() => {
            foreach (var token in requestData.ProductAccessTokens)
            {
                // this function will extract the specific product request ( one request can contain multiple products )
                var details = SplitQuoteByProduct(requestData, responseData, token);
                lock(_padlock)
                {
                    _productDetails.AddOrUpdate(token, new List<QuoteDetails>() { details }, (productId, list) =>
                    {
                        list.Add(details);
                        return list;
                    });
                }
            }
        });
    }
    // this function will be executed by a timer every N amount of time
    public void SaveRequestsToDatabase()
    {
        Dictionary<string, List<QuoteDetails>> offboardingDictionary;
        lock (_padlock)
        {
            offboardingDictionary = _productDetails;
            _productDetails = new  Dictionary<string, List<QuoteDetails>>();
        }
        foreach (var item in offboardingDictionary)
        {
            // copy curent items and start a task which will process them
            SaveProductRequests(item.Key, item.Value.ToList());
            // clear curent items
            item.Value.Clear();
        }
    }
    public async Task SaveProductRequests(string productId, List<QuoteDetails> productRequests)
    {
        // save received items to database
        /// ...
    }
    private readonly object _padlock = new object();
