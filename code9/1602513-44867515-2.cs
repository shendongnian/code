    public Task<List<UsageSummaryModel>> GetBilledUsageSummary(int accountId, string billingRunId)
        {
            string endPointFormat= BaseUrl + "{0}{1}/{2}/usage";
            return AsyncHandler<List<UsageSummaryModel>>.GetAsyncHandler(endPointFormat, accountId, billingRunId);
        }
        public Task<List<UsageSummaryModel>> GetUnBilledUsageSampleRunId(int accountId)
        {
            string endPointFormat = BaseUrl + "{0}{1}/sample?usageonly=true";
            return AsyncHandler<List<UsageSummaryModel>>.GetAsyncHandler(endPointFormat, accountId);
        }
