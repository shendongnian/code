    public string ProductCountInfo
    {
        get
        {
            return Products != null && Products.Any() ? Products.Count().ToString() : "none";
        }
    }
    // Or in C# 6+
    // public string ProductCountInfo => Products?.Count()?.ToString() ?? "none";
