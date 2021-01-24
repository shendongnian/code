    using (TextFieldParser parser = new TextFieldParser(path))
    {
        // set the parser variables
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
 
        bool firstLine = true;
 
        while (!parser.EndOfData)
        {
            //Processing row
            string[] fields = parser.ReadFields();
 
            // get the column headers
            if (firstLine)
            {
                firstLine = false;
 
                continue;
            }           
        }
    }
