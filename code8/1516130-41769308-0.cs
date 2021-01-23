    private static dynamic[] GetDataArray(
        decimal rangeMax,
        decimal rangeMin,
        string originMax,
        string originMin,
        string destMax,
        string destMin)
    {
        return new dynamic[6] { // Data
            /* RangeMax */
            new List<decimal> { rangeMax },
            /* RangeMin */
            new List<decimal> { rangeMin },
            /* OriginMax */
            new List<string>  { originMax },
            /* OriginMin */
            new List<string>  { originMin },
            /* DestinationMax */
            new List<string>  { destMax },
            /* DestinationMin */
            new List<string>  { destMin }
        };
    }
