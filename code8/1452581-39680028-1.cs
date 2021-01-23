    public void ProcessApiData(List<Account> apiData)
    {
        // Insert or Update using the primary key (AccountID)
        CurrentUnitOfWork.BulkMerge(apiData);
    }
