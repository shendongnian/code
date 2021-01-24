    using Microsoft.VisualBasic.FileIO;
    void Main()
    {
        var inputFilename = @"G:\Test\TestCsv.csv";
        var outputFilename = @"G:\Test\TestCsvOut.csv";
    
        using (var tfp = new TextFieldParser(inputFilename))
        using (var strm = new StreamWriter(outputFilename))
        {
            tfp.Delimiters = new string[] { "," };
            tfp.HasFieldsEnclosedInQuotes = true;
            tfp.TextFieldType = FieldType.Delimited;
            tfp.TrimWhiteSpace = true;
    
            while (!tfp.EndOfData)
            {
                string[] fields = tfp.ReadFields();
                //Add quotes to fields that contain commas
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i].Contains(","))
                    {
                        fields[i] = $"\"{fields[i]}\"";
                    }
                }
                //string.Join to create a delimited string
                strm.WriteLine(string.Join(",", fields));
            }
        }
    }
