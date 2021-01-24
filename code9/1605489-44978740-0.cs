    [DataContract]
    public class Data
    {
        [DataMember(Name = "detections")]
        public List<List<Detection>> Detections { get; set; }
    }
