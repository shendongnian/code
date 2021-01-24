    public async Task<IEnumerable<IEnumerable<string>> GetAll(
        IEnumerable<string> adresses, 
        IEnumerable<string> postalCodes)
    {
        // Start all tasks one by one without waiting for responses
        var tasks = addresses.Zip(postalCodes, (addr, code) => GetData(addr, code));
        await Task.WhenAll(tasks);
        return tasks.Select(task => task.Result).ToList();
    }
