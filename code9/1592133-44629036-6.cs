        public class StateObject
        {
            public long connectionNumber = -1;
            public Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
            public int fifoCount { get; set;}
            public string IMEI { get; set; }
        }
