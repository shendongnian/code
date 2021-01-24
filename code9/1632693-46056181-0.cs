    public string ShowCounts()
    {
        var results = new List<string>();
        if (this.Count1 > 0)
        {
            results.Add($"{this.Count1} Count1");
        }
        if (this.Count2 > 0)
        {
            results.Add($"{this.Count2} Count2");
        }
        if (this.Count3 > 0)
        {
            results.Add($"{this.Count3} Count3");
        }
        return results.Any() ? string.Join("\n", results) : "";
    }
