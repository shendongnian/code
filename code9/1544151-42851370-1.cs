    public class CsvDataAttribute : DataAttribute
    {
        readonly string fileName;
        public CsvDataAttribute(string fileName)
        {
            this.fileName = fileName;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //Parse CSV and return an object[] for each test case
        }
    }
