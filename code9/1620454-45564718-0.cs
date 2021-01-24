        var ZipReadTable = new DataTable(); 
            ZipReadTable.Columns.Add("ZipCol1");
            using (Stream fileStream = File.OpenRead(FileName), 
                zippedStream = new GZipStream(fileStream, CompressionMode.Decompress))
            {
                using (StreamReader reader = new StreamReader(zippedStream))
                {
                    while (!reader.EndOfStream)
                    {
                        ZipReadTable.Rows.Add(reader.ReadLine());
                    }
                }
            }
            string[] ParsedLine = null;
            string NotParsedLine = null;
            char Delimiter = '|';
            for (int k = 0; k < ZipReadTable.Rows.Count; k++)
            {
                NotParsedLine = ZipReadTable.Rows[k][0].ToString();
                ParsedLine = NotParsedLine.Split(Delimiter);
                OutputTable.Rows.Add(ParsedLine);
            }
            return (OutputTable);
