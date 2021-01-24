            using (var file = new StreamWriter("test.csv"))
            {
                var writer = new CsvWriter(file);
                writer.Configuration.CultureInfo = CultureInfo.GetCultureInfo("en-US");
                writer.WriteRecords(items);
            }
            using (var file = new StreamReader("test.csv"))
            {
                var reader= new CsvReader(file);
                reader.Configuration.CultureInfo = CultureInfo.GetCultureInfo("en-US");
                var models=reader.GetRecords<MyModel>().ToArray();
                Console.WriteLine(models[0]);                
            }
