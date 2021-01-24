    public class CalculationModel
    {
        public int Number { get; set; }
        public int Result { get; set; }
        public bool Processed { get; set; }
        public CalculationModel()
        {
            Processed = false;
        }
    }
