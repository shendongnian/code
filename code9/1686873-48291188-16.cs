    public IEnumerable<DurationModel> GetDurationItems()
    {
        // This works because arrays implement IEnumerable<T>.
        return new DurationModel[] {
            new DurationModel { Duration = "1 Day" },
            new DurationModel { Duration = "1 Week" },
            new DurationModel { Duration = "1 Month" }
        };
    }
