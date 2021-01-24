    public class LeadDataView
    {
        public string ResponseContinuation { get; set; }
        public FeedResponse<Infinity> InfinityDataView { get; set; }
    }
    if (query.HasMoreResults)
                {
                    var result = await query.ExecuteNextAsync<Infinity>();
                    objLeadDataView.ResponseContinuation = result.ResponseContinuation;
                    objLeadDataView.InfinityDataView = result;
                    response = objLeadDataView;
                }
