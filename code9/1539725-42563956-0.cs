    you can use [Range] attribute someting like this
    
    [DataContract]
    public class Test
    {
        [DataMember]
        [Range(1, 10)]
        public int Name{ get; set; }
    }
