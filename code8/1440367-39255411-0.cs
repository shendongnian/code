        using (TextReader reader = File.OpenText("Pasta1.csv"))
        {
            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = ",";
            while (csv.Read())
            {
                CustomerClass record = new CustomerClass();
                record.CustomerID = (string)csv.GetField(typeof(string), "CustomerID");
                if (string.IsNullOrEmpty(record.CustomerID))
                {
                    //CustomerID is null
                }
                if (!csv.TryGetField<DateTime>("EffectiveDate", out record.EffectiveDate))
                {
                    //EffectiveDate incorrect
                }
            }
        }
