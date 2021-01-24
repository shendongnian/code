    public string ProductCountInfo
    {
        get
        {
            return Products != null && Products.Any() ? Products.Count().ToString() : "none";
        }
    }
