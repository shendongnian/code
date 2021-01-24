            var dFm = new DateTime(2015, 01, 25);
            var dTo = new DateTime(2015, 01, 27);
            using (var reader = File.OpenText(@"sample.csv"))
            {
                var csv = new CsvReader(reader);
                while (csv.Read())
                {
                    var date = csv.GetField<DateTime>("Date");
                    if (date >= dFm &&
                        date <= dTo)
                    {
                        // process the filtered out records
                    }
                }
            }
