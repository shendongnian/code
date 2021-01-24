    public class AudioSampleEntityModel : TableEntity
        {
            public AudioSampleEntityModel()
            {
    
            }
            public AudioSampleEntityModel(string partitionName, string id)
            {
    
            }
            public string id { get; set; }
            public string Blob { get; set; }
            public string SampleBlob { get; set; }
            public string SampleBlobURL { get; set; }
            public DateTime CreatedDate { get; set; }
            public string SampleDate { get; set; }
        }
