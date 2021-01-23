     public class SnifferMessage
    {
        public string Node {get; set; }
        public byte Command { get; set; }
        public DateTime Time { get; set; }
        public string Payload { get; set; }
        public string Metadata { get; set; }
    }
