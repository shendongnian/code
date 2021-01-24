    public class Tip
    {
        public string Home { get; set; }
        public string Away { get; set; }
        public string Prediction { get; set; }
    
        public int TipsterId { get; set; }
    
        public Tipster Tipster { get; set; }
        ... other properties
    }
