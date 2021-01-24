    public bool IsDateInRange(DateTime value, DateTime? min, DateTime? max)
    {
        //Use provided min/max times if they were not null. Fallback to Min/Max supported values from DateTime
        min = min ?? DateTime.MinValue;
        max = max ?? DateTime.MaxValue;
        return value >= min && value <= max;
    }
