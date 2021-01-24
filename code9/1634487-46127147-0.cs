    public class TransportDto
    {
        public int type { get; set; }
        public string url { get; set; }
        public int Relationship { get; set; }
        public TransportDto Clone(){
            return new TransportDto{
                type = type,
                url = url,
                Relationship = Relationship
            };
        }
    }
