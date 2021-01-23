    public async Task<IEnumerable<Record>> GetRecordsInRange(DateTime startDate, 
                                                             DateTime endDate)
    {
        while (startDate <= endDate)
        {
            List<Record> results = new List<Record>();
            // send requests in order you want
            var taskA = ExecuteQueryAPIAsync(startDate, QueryTypes.A);
            var taskB = ExecuteQueryAPIAsync(startDate, QueryTypes.B);
            var taskC = ExecuteQueryAPIAsync(startDate, QueryTypes.C);
            // observes results in same order
            var resultA = await taskA;
            results.AddRange(resultA);
            var resultB = await taskB;
            results.AddRange(resultB);
            var resultC = await taskC;
            results.AddRange(resultC);
            // Jump to the next day.
            startDate = startDate.AddDays(1);
        }
        
        return results;
    }
