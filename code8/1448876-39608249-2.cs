    public static async Task<SampleDataGroup> GetGroupByItemAsync(SampleDataItem item)
    {
        await _DataItemSource.GetSampleDataAsync();
        // Simple linear search is acceptable for small data sets
        var matches = _DataItemSource.Groups.Where(group => group.Items.Contains(item));
        if (matches.Count() == 1) return matches.First();
        return null;
    }
