    public SelectList GetDateRanges(DateTime startDate, DateTime endDate)
    {
        var query = from t in db.Transactions
                    where t.TransactionDate >= startDate &&
                          t.TransactionDate <= endDate
                    select t;
        ...
    }
