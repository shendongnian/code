    public async Task Process(object source)
    {
        using (var enumerator = source.ToAsyncEnumerable().GetEnumerator())
        {
            while (await enumerator.MoveNext())
            {
                var item = enumerator.Current;
            }
        }
    }
