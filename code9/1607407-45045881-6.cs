    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class PlantMetadata
    {
        [JsonProperty]
        public object Cells { get; set; }
        [JsonProperty]
        public object GenericName { get; set; }
        [JsonProperty]
        public object FieldIWantSerialized;
    } 
