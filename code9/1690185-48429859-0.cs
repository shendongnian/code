    public class Zoo
    {
        [XmlIgnore]
        public Animal? animAsEnum { get; set; }
        public string anim { get; set; }
        [OnDeserialized]
        private void OnDeserializedMethod(StreamingContext context)
        {
    	    Animal animAsEnum;
    	    if (Enum.TryParse(anim, out animAsEnum))
    	    {
    	        this.animAsEnum = animAsEnum;
    	    }
    	}
    }
