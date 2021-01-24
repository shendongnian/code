    public class Result
        {
            public List<object> brands { get; set; }
            public List<object> services { get; set; }
            public List<object> addresses { get; set; }
            public List<object> accessPoints { get; set; }
            public string Kodu { get; set; }
            public string name { get; set; }
            public string taxNumber { get; set; }
            public string taxOffice { get; set; }
            public string id { get; set; }
            public bool isActive { get; set; }
        }
    
        public class RootObject
        {
            public List<Result> result { get; set; }
            public int id { get; set; }
            public object exception { get; set; }
            public int status { get; set; }
            public bool isCanceled { get; set; }
            public bool isCompleted { get; set; }
            public bool isCompletedSuccessfully { get; set; }
            public int creationOptions { get; set; }
            public object asyncState { get; set; }
            public bool isFaulted { get; set; }
        }
