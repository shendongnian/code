    public double? AverageRating
    {
        get
        {
            return Reviews?.DefaultIfEmpty(null).Average(x => x?.Rating);
        }
    }
