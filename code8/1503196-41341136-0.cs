    public static String[] GetHeaders(string filePath)
        {
            using (CsvReader csv = new CsvReader(new StreamReader("data.csv")))
            {
                csv.Configuration.HasHeaderRecord = true;
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
            }
        }
