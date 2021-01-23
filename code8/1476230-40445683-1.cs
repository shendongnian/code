    class MainModel
    {
        public Model BaseModel { get; set; }
        public ModelOne ModelOne { get; set; }
        public ModelTwo ModelTwo { get; set; }
    }
    class Model
    {
        public int BaseValue { get; set; }
    }
    class ModelOne : Model
    {
        public int OneValue { get; set; }
    }
    class ModelTwo : Model
    {
        public int TwoValue { get; set; }
    }
