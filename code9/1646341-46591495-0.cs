    IEnumerable<Data> GetData() {
        int start = 0, end = 10;
        bool hasData = true;
        using (MehrpouyanEntities dbContext = new MehrpouyanEntities()) {
            for (int i = 1; hasData; ++i) {
                int n = i;
                hasData = false;
                var query = dbContext.ReservedServices.Where(r =>
                                DbFunctions.AddDays(r.LastServiceDate, n * r.Duration) >= start &&
                                DbFunctions.AddDays(r.LastServiceDate, n * r.Duration) <= end);
                foreach (var item in query) {
                    hasData = true;
                    yield return item;
                }
            }
        }
    }
