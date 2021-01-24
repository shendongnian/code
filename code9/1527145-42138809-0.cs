    public Task Handle(ReceiveEventsFromSalesForceCommand message, IMessageHandlerContext context) {
        return this.GenerateQueryResultAsync(message).ConfigureAwait(false);
    }
    
    public async Task<QueryResult<EventStore__c>> GenerateQueryResultAsync(ReceiveEventsFromSalesForceCommand message) {
        QueryResult<EventStore__c> queryResult;
        if (string.IsNullOrWhiteSpace(message.NextRecordsUrl)) {
            queryResult = await this.forceClient.QueryAsync<EventStore__c>(query).ConfigureAwait(false);
            if(queryResult != null)
                this.log.Info($"AFTER: QueryAllAsync<EventStore>(query), found {queryResult.TotalSize} records");
            else 
                this.log.Info($"AFTER: QueryAllAsync<EventStore>(query), found 0 records");
        } else {
            queryResult = await this.forceClient.QueryContinuationAsync<EventStore__c>(message.NextRecordsUrl).ConfigureAwait(false);
            this.log.Info("AFTER: QueryContinuationAsync<EventStore>(query)" );
        }
        return queryResult;
    }
