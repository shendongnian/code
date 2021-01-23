        public static class CSVUtils
    {
        public static void AddCsvLine(bool isFrenchSeparator, StringBuilder csv, params object[] values)
        {
            foreach (var value in values)
            {
                csv.Append('"').Append(value).Append('"');
                if (isFrenchSeparator)
                {
                    csv.Append(';');
                }
                else
                {
                    csv.Append(',');
                }
            }
            csv.Append('\r'); // AppendLine() adds a double line break with UTF32Encoding
        }
    }
        public FileContentResult ExportCSV()
        {
            StringBuilder csv = new StringBuilder();
            CSVUtils.AddCsvLine(false, csv, "Field1", "Field2", "Field3");
            CSVUtils.AddCsvLine(false, csv, "value1", "value2", "value3");
            return this.File(new UTF32Encoding().GetBytes(csv.ToString()), "text/csv", "myfile.csv");
        }
