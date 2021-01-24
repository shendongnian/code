    // add this using statement for TextFieldParser - needs reference to Microsoft.VisualBasic assembly
    using Microsoft.VisualBasic.FileIO;
    ...
    // TextFieldParser implements IDisposable so you can let a using block take care of opening and closing
    using (TextFieldParser parser = new TextFieldParser(Fname))
    {
        // configure your parser to your needs
        parser.TextFieldType = FieldType.Delimited;
        parser.Delimiters = new string[] { ";" };
        parser.HasFieldsEnclosedInQuotes = false; // no messy code if your data comes with quotes: ...;"text value";"another";...
        // read the first line with your headers
        string[] fields = parser.ReadFields();
        // add the desired headers with the desired data type
        dt.Columns.Add(fields[2], typeof(string));
        dt.Columns.Add(fields[4], typeof(string));
        // read the rest of the lines from your file
        while (!parser.EndOfData)
        {
            // all fields from one line
            string[] line = parser.ReadFields();
            // create a new row <-- this is missing in your code
            DataRow row = dt.NewRow();
            // put data values; cast if needed - this example uses string type columns
            row[0] = line[2];
            row[1] = line[4];
            // add the newly created and filled row
            dt.Rows.Add(row);
        }
    }
    // asign to DGV
    this.dataGridView1.DataSource = dt;
