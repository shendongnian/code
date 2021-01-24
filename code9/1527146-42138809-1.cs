    public async Task<QueryResult<EventStore__c>> GenerateQueryResultAsync(ReceiveEventsFromSalesForceCommand message) {
        QueryResult<EventStore__c> queryResult;
        if (string.IsNullOrWhiteSpace(message.NextRecordsUrl)) {
            queryResult = await this.forceClient.QueryAsync<EventStore__c>(query).ConfigureAwait(false);
            this.log.Info($"AFTER: QueryAllAsync<EventStore>(query), found {queryResult?.TotalSize ?? 0} records");
        } else {
            queryResult = await this.forceClient.QueryContinuationAsync<EventStore__c>(message.NextRecordsUrl).ConfigureAwait(false);
            this.log.Info("AFTER: QueryContinuationAsync<EventStore>(query)" );
        }
        return queryResult;
    }
