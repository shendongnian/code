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
                        lastRow += Encoding.Default.GetString(buffer);
                        // clear the buffer.
                        buffer = new byte[blockSize];
                        //parse the file
                        string[] rows = lastRow.Split(new string[] { "#####" }, StringSplitOptions.None); //ParserConstants.RowSeparator }, StringSplitOptions.None);
                        // We cannot process the last row in this set because it may not be a complete
                        // row, and tokens could be clipped.
                        if (rows.Count() > 1)
                        {
                            for (int i = 0; i < rows.Count() - 1; i++)
                            {
                                string[] columns = rows[i].Split(new string[] { "'~'" }, StringSplitOptions.None); // ParserConstants.ColumnSeparator }, StringSplitOptions.None);
                                foreach (string column in columns)
                                {
                                    sw.Write(column + "\t");
                                }
                                sw.Write(Environment.NewLine);
                                //sw.Write(ParserConstants.NewlineCharacter);
                            }
                        }
                        lastRow = rows[rows.Count() - 1];
                        parsedBytes += bytes;
                        // The following statement is not quite true because we haven't parsed the lastRow.
                        Console.WriteLine($"Parsed {parsedBytes.ToString():N0} bytes");
                        Debug.WriteLine($"Parsed {parsedBytes.ToString():N0} bytes");
                    }
                    // Now that there are no more bytes to read, we know that the lastrow is complete.
                    string[] finalcolumns = lastRow.Split(new string[] { "'~'" }, StringSplitOptions.None); // ParserConstants.ColumnSeparator }, StringSplitOptions.None);
                    foreach (string column in finalcolumns)
                    {
                        sw.Write(column + "\t");
                    }
                    sw.Write(Environment.NewLine);
                    //sw.Write(ParserConstants.NewlineCharacter);
                }
            }
            Console.WriteLine("File Parsing completed.");
            Debug.WriteLine("File Parsing completed.");
        }
