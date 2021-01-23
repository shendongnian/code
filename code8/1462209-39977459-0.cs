    public async Task<bool> StartAsync(string programName, CancellationToken token = default(CancellationToken))
    {
        IEnumerable<Task<bool>> startingChannels = _accounts.GetPrograms(programName))
                                                            .Select(n => StartChannelAsync(n))
                                                            .ToArray();
        bool[] results = await Task.WhenAll(startingChannels);
        return results.All(r => r);
    }
