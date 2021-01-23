    public IEnumerable<decimal> ActualHours(params decimal[] values)
    {
        foreach (var v in values)
        {
            var t = Math.Truncate(v);
            yield return t + (v - t) / 0.6m;
        }
    }
    public string Print(decimal v)
    {
        var t = Math.Truncate(v);
        return (t + (v - t) * 0.6m).ToString("0.00");
    }
