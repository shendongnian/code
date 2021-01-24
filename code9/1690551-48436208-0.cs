    public class DataValues
    {
        public int yearBuilt;
        public decimal price;
        private static Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        public static DataValues FromCSV(string csvLine)
        {
            var result = new DataValues();
            
            string[] values = CSVParser.Split(csvLine);
            
            values[0] = values[0].Replace("," , "").Replace("$","");
            result.price = decimal.Parse(values[0]);
            result.yearBuilt = int.Parse(values[1]);
            return result;
        }
    }
