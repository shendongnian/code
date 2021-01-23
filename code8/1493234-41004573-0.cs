    public class RootObject
    {
        [JsonProperty(PropertyName ="Machine Learning Functions")]
        public List<MachineLearningFunction> MachineLearningFunctions { get; set; }
        [JsonProperty(PropertyName ="Math Functions")]
        public List<MathFunction> MathFunctions { get; set; }
    }
