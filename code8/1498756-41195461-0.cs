    public class AudioFile
    {
        //TODO: DB generated
        [Key]
        public int ID { get; set; }
        //This will automatically map to varbinary(max)
        public byte[] FileData { get;set; }
        public string LocalFileName { get;set;}
        public string MIMEType {get;set;}
    }
