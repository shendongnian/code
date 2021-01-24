    [JsonConverter(typeof(StringEnumConverter))]
    public enum WayBillType
    {
        Moving = 1,
        Incoming = 2,
        Disposal = 3
    }
