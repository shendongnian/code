    //Metadata.cs
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(PlantMetadata))]
    public sealed partial class Plant
    {
        [JsonObject(MemberSerialization.OptIn)]
        internal sealed class PlantMetadata
        {
            [JsonProperty]
            public IEnumerable<ICell> Cells { get; set; }
            [JsonProperty]
            public string GenericName { get; set; }
            [JsonProperty]
            public string FieldIWantSerialized;
        }
    }
