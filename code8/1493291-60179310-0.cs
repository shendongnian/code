    public class Test
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int HiddenProperty { get; set; }
        public int VisibleProperty { get; set; }
    }
