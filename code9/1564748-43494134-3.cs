    public sealed class CanonData
    {
        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint ModelId { get; set; }
        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint FirmwareRevision { get; set; }
    }
