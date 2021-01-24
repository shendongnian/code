    public class PersonTotal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Bought { get; set; }
        public int Referred { get; set; }
        public int Total 
        { 
            get { return Bougth + Referred; } 
        }
    }
