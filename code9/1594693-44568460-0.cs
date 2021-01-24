    public class Toyota : CarsBase
    {
        public Toyota() : base()
        {
            base.DisplayName = "Toyota";
        }
        public EngineType EngineType { get; set; }
    }
