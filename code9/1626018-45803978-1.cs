    [Flags]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum Difficulty
    {
        F = 1,
        PD = 2,
        AD = 4,
        D = 8,
        TD = 16,
        ED = 32
    };
