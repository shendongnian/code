    public SelectList GetDateRanges(int daysBack)
    {
        var oldestDate = (DateTime.Today).AddDays(daysBack * -1);
        var query = from t in db.Transactions
                    where t.TransactionDate >= oldestDate
                    select t;
        ...
    }
