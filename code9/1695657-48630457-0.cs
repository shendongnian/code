    public class ConverterDictionary
    {
        public Dictionary<string, double> Units { get; }
        public ConverterDictionary()
        {
            Units = new Dictionary<string, double>
            {
                {"Feet", 1},
                {"Meters", .3048}
            };
        }
    }
