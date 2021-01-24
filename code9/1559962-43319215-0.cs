    [DataContract]
    public class SaveDataSetRequest
    {
        [DataMember]
        public DataSet Data { get; set; }
    
        [DataMember]
        public string FileName { get; set; }
    
       // you can add more properties here in the future versions without effecting the existing clients.
    }
