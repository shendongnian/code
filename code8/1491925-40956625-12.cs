    public class ConverterToContinentalUnit
    {
        public char Key { get; set; }
        public double Coefficent { get; set; }
        public string PrefixForResult { get; set; }
        public string GetFormattedResult(int value)
        {
            var continentalUnit = input / Coefficent;
            return $"{PrefixForResult}: {continentalUnit}";
        }
    }
    public class ConverterCollection: KeyedCollection<int, ConverterToContinentalUnit>
    {
        // This need to be implemented and return key value
        protected override int GetKeyForItem(ConverterToContinentalUnit item)
        {
            return item.Key ;
        }
    }
