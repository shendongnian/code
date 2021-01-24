    using (StreamReader rdr = new StreamReader(inputfile))
    using (StreamWriter sw = new StreamWriter(outputfile))
    {
        char[] buffer = new char[256];
        int read;
        
        //Write the Header row
        sw.Write(header);
           
        string remainder = string.Empty;
        while ((read = rdr.Read(buffer, 0, 256)) > 0)
        {
            string bufferData = new string(buffer, 0, read);
            //parse the file
            string[] rows = bufferData.Split(
                new string[] { ParserConstants.RowSeparator },
                StringSplitOptions.None);
            rows[0] = remainder + rows[0];
            int completeRows = rows.Length - 1;
            remainder = rows.Last();
            foreach (string row in rows.Take(completeRows))
            {
                string[] columns = row.Split(
                    new string[] {ParserConstants.ColumnSeparator},
                    StringSplitOptions.None);
                foreach (string column in columns)
                {
                    sw.Write(column + "\\t");
                }
                sw.Write(ParserConstants.NewlineCharacter);
                Console.WriteLine();
            }
        }
        if(reamainder.Length > 0)
        {
            string[] columns = remainder.Split(
            new string[] {ParserConstants.ColumnSeparator},
            StringSplitOptions.None);
            foreach (string column in columns)
            {
                sw.Write(column + "\\t");
            }
            sw.Write(ParserConstants.NewlineCharacter);
            Console.WriteLine();
        }
        Console.WriteLine("File Parsing completed");
    }
