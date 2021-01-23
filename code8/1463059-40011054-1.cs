    public class Text
    {
        [JsonProperty(PropertyName ="@fontName")]
        public string FontName {get; set;}
        
        [JsonProperty(PropertyName ="@fontSize")]
        public string FontSize {get; set;}
    
        [JsonProperty(PropertyName ="#text")]
        public string TextResult{get; set;}
        
        //other objects
    }
    
    public class Column
    {
        public List<Text> text { get; set; }
    }
