    public IEnumerable<DurationModel> GetDurationItems()
    {
        return new DurationModel[] {
            new DurationModel { Duration = "1 Day" },
            new DurationModel { Duration = "1 Week" },
            new DurationModel { Duration = "1 Month" }
        };
    }
