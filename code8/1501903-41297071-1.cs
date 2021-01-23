     public class Response
        {
            public string MeterID { get; set; }
            public string KWHMainActual { get; set; }
            public string KWActual { get; set; }
            public string KWHDGActual { get; set; }
            public string MeterOnOff { get; set; }
            public string MeterDefective { get; set; }
            public string RecordDateTime { get; set; }
        }
        
        public class RootObject
        {
            public string type { get; set; }
            public string error { get; set; }
            public string warning { get; set; }
            public string info { get; set; }
            public string response_code { get; set; }
            public List<Response> response { get; set; }
        }
