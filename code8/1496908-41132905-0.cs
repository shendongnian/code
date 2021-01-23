     public class Predictions
    {
        public string Prediction { get; set; }
        public string Refs { get; set; }
        public bool Complete { get; set; }
    }
    public class PredictionsList
    {
        public List<Predictions> Predictions { get; set; }
        public string Status { get; set; }
    }
