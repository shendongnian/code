    public bool IsAllowed(string source, string dest)
    {
        var allowedDest = new []
        {
            new [] {"ABC", "010"},
            new [] {"ABC", "011"},
            new [] {"BAC", "010"}
            //...
        };
        var match = new [] { source, dest };
        return allowedDest.Any(x => x.SequenceEqual(match));
    }
