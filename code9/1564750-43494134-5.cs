    public sealed class CanonInfo
    {
        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint ModelId { get; set; }
        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint FirmwareRevision { get; set; }
    }
