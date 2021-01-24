    public class CreateChildCommand {
        [JsonSchema(JsonObjectType.String, Format = "guid")]
        public Parent Parent { get; set; }
        
        public int Position { get; set; }
    }
