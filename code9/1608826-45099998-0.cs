    [TestMethod]
    public async Task ParallelSQLMethod() {
        //real amount is more then 1500
        var keys = new long[] { 
            15072000173475, 
            15072000173571, 
            //....., n
        };
        var tasks = keys.Select(i => RunStoredProc(i));
        var batchSize = 50; //Or smaller
        //run tasks in batches
        var sequence = tasks;
        while (sequence.Any()) {
            var batch = sequence.Take(batchSize);
            sequence = sequence.Skip(batchSize);
            await Task.WhenAll(batch);
        }
    }
