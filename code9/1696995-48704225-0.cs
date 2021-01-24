    private Random random = new Random();
    public void TextRx()
    {
        new[] {"T-1", "T-2", "T-3"}
            .Select(s => ReturnResult(s).ToObservable())
            .Merge()
            .GroupBy(i => i % 2 == 0)
            .SelectMany(g => g.Select(i => (g.Key, Value: i)))
            .Subscribe(o => Console.WriteLine($"{(o.Key ? "EVEN" : "ODD")} VALUE {o.Value}"));
    }
    public async Task<int> ReturnResult(string s)
    {
        await Task.Delay(random.Next(5000));
        int.TryParse(s.Split('-')[1], out var result);
        return result;
    }
