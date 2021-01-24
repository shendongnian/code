      // HelperClass to pass for callbacks
      public class DownId
      {
         public int Id { get; set; }
      }
      // DownloadClass with all needed properties. Should be expanded for your needs.
      public class Downloads
      {
          public Driver()
            {
            }
            public string Title { get; set; }
            public string Filelink { get; set; }
            public string FileName { get; set; }
            public bool IsCanceling { get; set; }
            public WebClient Client { get; set; }
            public int Retry { get; set; }
            public int Progress { get; set; }
            public long valBytesRec { get; set; }
            public long valBytesTotal { get; set; }
      }
