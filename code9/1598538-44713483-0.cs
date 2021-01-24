     public async Task<double> CalculateAverageAge()
    {
        var client = new MobileServiceClient(AppUrl, AppKey);
        var table = client.GetTable<Person>();
        var sum = 0.0;
        var count = 0;
        var items = await table.Take(10).ToEnumerableAsync();
        while (items != null && items.Count() != 0)
        {
            count += items.Count();
            sum += Enumerable.Sum(items, i => i.Age);
            var queryResult = items as IQueryResultEnumerable<Person>;
            if (queryResult != null && queryResult.NextLink != null)
            {
                items = await table.ReadAsync<Person>(queryResult.NextLink);
            }
            else
            {
                items = null;
            }
        }
        return sum / count;
    }
