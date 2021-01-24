        static void Main(string[] args)
        {
            String specDataPath = @"C:\sample c# programs\FileHelpersTester\FileHelpersTester\bin\Debug\Sample.csv";
            String tester = GetValue<SpecDataOrder>(specDataPath, "2", nameof(SpecDataOrder.Index), nameof(SpecDataOrder.Name)) as string; //I expect the value of tester = "Jack"
        }
        public static object GetValue<T>(String csvFilePath, object rowIndex, String indexName, String fieldName)
        {
            var engine = new FileHelperEngine(typeof(T));
            var records = engine.ReadFile(csvFilePath);
            var memberIndex = new PropertyOrFieldInfo<T>(indexName);
            var memberField = new PropertyOrFieldInfo<T>(fieldName);
            foreach (T record in records)
            {
                var indexValue = memberIndex.GetValue(record);
                {
                    if (indexValue.Equals(rowIndex))
                    {
                        return memberField.GetValue(record);
                    }
                }
            }
            return null;
        }
