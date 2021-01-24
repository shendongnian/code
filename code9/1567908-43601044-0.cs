      public class file
        {
            //Since JsonConvert.SerializeObject couldn't serialize the stream object I used byte[] instead
            public byte[] str { get; set; }
            public string filename { get; set; }
    
            public string contentType { get; set; }
        }
