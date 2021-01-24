    public void ParseFile(string inputfile, string outputfile, string header)
    {
        int blockSize = 1024;
    
        using (var file = File.OpenRead(inputfile))
        {
            using (StreamWriter sw = new StreamWriter(outputfile))
            {
                int bytes = 0;
                int parsedBytes = 0;
                var buffer = new byte[blockSize];
                string lastRow = string.Empty;
    
                while ((bytes = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Because the buffer edge could split a RowDelimiter, we need to keep the
                    // last row from the prior split operation.  Append the new buffer to the
                    // last row from the prior loop iteration.
                    lastRow += Encoding.Default.GetString(buffer,0, bytes);
    
                    //parse the file
                    string[] rows = lastRow.Split(new string[] { ParserConstants.RowSeparator }, StringSplitOptions.None);
    
                    // We cannot process the last row in this set because it may not be a complete
                    // row, and tokens could be clipped.
                    if (rows.Count() > 1)
                    {
                        for (int i = 0; i < rows.Count() - 1; i++)
                        {
                            sw.Write(new Regex(ParserConstants.ColumnSeparator).Replace(rows[i], "\t") + ParserConstants.NewlineCharacter);
                        }
                    }
                    lastRow = rows[rows.Count() - 1];
                    parsedBytes += bytes;
                    // The following statement is not quite true because we haven't parsed the lastRow.
                    Console.WriteLine($"Parsed {parsedBytes.ToString():N0} bytes");
                }
                // Now that there are no more bytes to read, we know that the lastrow is complete.
                sw.Write(new Regex(ParserConstants.ColumnSeparator).Replace(lastRow, "\t"));
            }
        }
        Console.WriteLine("File Parsing completed.");
    }
