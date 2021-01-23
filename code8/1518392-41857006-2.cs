    class Message {
        public DateTime DateTime { get; set; }
        public int Protocol { get; set; }
        public string Type { get; set; }
        public string Measurement {get;set;}
        public Message(string[] data) {
           Protocol = int.Parse(data[0]);
           Type = data[1];
           Measurement = data[2];
           DateTime = DateTime.Parse(data[3]);
        }
    }
