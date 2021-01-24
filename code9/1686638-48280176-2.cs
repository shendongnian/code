    public async Task<TransactionResponse> SaveAsync(TransactionRequest request)
    {
        await this._mongoClient.GetDatabase("MyDatabase")
                  .GetCollection<TransactionRequest>("Transactions")
                  .InsertOneAsync(request, null, CancellationToken.None);
        // load document - not needed, just for illustration purposes
        this._mongoClient.GetDatabase("MyDatabase")
            .GetCollection<TransactionRequest>("Transactions")
            .Find(t => t.Transaction.Id == request.Transaction.Id);
        return new TransactionResponse
        {
            InternalId = request.Id,
            TransactionId = request.Transaction.Id
        };
    }
