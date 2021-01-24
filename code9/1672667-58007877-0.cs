        public void CreateCsv()
        {
            // populate data with records
            IEnumerable<SampleDataClass> data;
            var _csvConfiguration = new CsvHelper.Configuration.Configuration {
                ShouldQuote = (field, ctx) => false
            };
            using (var file = File.CreateText(_outputFileName))
            using (var csv = new CsvWriter(file, _csvConfiguration))
            {
                csv.WriteHeader<SampleDataClass>();
                csv.NextRecord();
                while (data.MoveNext())
                {
                    csv.WriteRecord(data.Current);
                    csv.NextRecord();
                }
            }
        }
        public class SampleDataClass
        {
            public string product_id { get; set; }
            public string order_id { get; set; }
            public string user_id { get; set; }
        }
