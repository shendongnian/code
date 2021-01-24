    static int index(int sourceIndex, IEnumerable<string> array, string destination)
    {
        return array
            // convert items stream into (item, index) pair
            .Select((item, index) => new { Item = item, Index = index })
            // skip items until condition is met
            .SkipWhile(c => c.Index <= sourceIndex || c.Item != destination)
            // we need index only
            .Select(c => c.Index)
            // if we found nothing - return -1
            .DefaultIfEmpty(-1)
            .First();            
    }
