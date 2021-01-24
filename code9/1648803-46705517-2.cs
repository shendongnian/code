            using (var file = new StreamWriter("test.csv"))
            {
                var writer = new CsvWriter(file);
                writer.Configuration.CultureInfo = CultureInfo.GetCultureInfo("en-US");
                writer.Configuration.RegisterClassMap<CsvMap>();
                writer.WriteRecords(items);
            }
            using (var file = new StreamReader("test.csv"))
            {
                var reader= new CsvReader(file);
                reader.Configuration.CultureInfo = CultureInfo.GetCultureInfo("en-US");
                reader.Configuration.RegisterClassMap<CsvMap>();                
                var models=reader.GetRecords<MyModel>().ToArray();
                Console.WriteLine(models[0]);                
            }
    Date,ID
    10/12/2017 11:56:11.016,1
    10/11/2017 11:56:11.021,2
