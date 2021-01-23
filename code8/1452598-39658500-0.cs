            var data = new Dictionary<string, object> { 
                {"Field1", "a string"},
                {"Field2", "00001"}
            };
            using(var writer = new StringWriter())
            {
                var config = new CsvConfiguration { UseExcelLeadingZerosFormatForNumerics = true };
                var csv = new CsvWriter(writer, config);
                if(data != null)
                {
                    foreach(var key in data.Keys)
                    {
                        csv.WriteField(key);
                    }
                    csv.NextRecord();
                    foreach (var key in data.Keys)
                    {
                        csv.WriteField(data[key]);
                    }
                    csv.NextRecord();
                }
            }
