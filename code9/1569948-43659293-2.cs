    public class ClassToConvert()
    {
        [JsonIgnore] // it will not be on the json
        public celle celleValue {get;set;}
        [JsonProperty(PropertyName = "c1")]
        public int celleShort
        {
            get
            {
                return (int)this.celleValue;
            }
        }
    }
    
    public enum celle 
    {
         apn = 0, 
         userName = 1, 
         password = 2, 
         number = 3 
    };
