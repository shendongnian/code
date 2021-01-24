    public class DTO
    {
        [JsonIgnore]
        public FlagsEnum Prop1 { get; set; }
      
        public int Prop1Serialize { 
           get { return (int)Prop1; }
           set { Prop1 = (FlagsEnum)value; }
        }
    }
