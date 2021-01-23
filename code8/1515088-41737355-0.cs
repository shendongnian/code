    public class Form 
    {
        [JsonProperty(ItemConverterType = typeof(MyJsonConverter))]
        public IList<IControl> Controls { get; set; }
    }
    
