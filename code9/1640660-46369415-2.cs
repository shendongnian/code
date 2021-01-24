    public class NameA
    {
        public List<List<double>> ParametersA { get; set; }
        public List<List<double>> ParametersB { get; set; }
    }
    
    public class NameB
    {
        public List<List<double>> ParametersA { get; set; }
        public List<List<double>> ParametersB { get; set; }
    }
    
    public class RootObject
    {
        public NameA NameA { get; set; }
        public NameB NameB { get; set; }
        public List<string> ThousandsNamesN { get; set; }
    }
