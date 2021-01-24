    public static Dictionary<string, ForecastType> FullTime { get; } = 
        new Dictionary<string, ForecastType>
        {
            { "1", new ForecastType 
                { 
                    Type = SignType.PartialFinal, 
                    Sign = Signs.HomeHomePF 
                } 
            // ...
        };
