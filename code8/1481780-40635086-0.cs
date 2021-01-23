    public class PICKUPREQUESTRESPONSE
    {
        [XmlArray("PICKUPREQUESTRESPONSE")]
        [XmlArrayItem("STATUS", typeof(STATUS))]
        public STATUS[] STATUS { get; set; }
    }
