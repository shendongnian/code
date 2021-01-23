    using (TextFieldParser parser = new TextFieldParser(@"c:\temp\test.txt")) 
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters("\n");
        string csvData = "";
        while (!parser.EndOfData) 
        {
            //Processing row
            string[] fields = parser.ReadFields();
            foreach (string field in fields) 
            {
                csvString += field + ",";
            }
            csvString += "\n";
        }
    }
