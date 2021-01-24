    [DataContract]
    public class UploadData
    {
        [DataMember]
        string userId { get; set; }
        
        [DataMember]
        Stream uploadingDetails { get; set; }
    }
    public class YourService : IYourService
    {
    
        public bool  UploadFile(UploadData request)
        {
        }
    }
