            public static DataTable CsvDb(string filename, string separatorChar)
        {
            var table = new DataTable("Filecsv");
            using (var sr = new StreamReader(filename, Encoding.Default))
            {
                string line;
                var i = 0;
                while (sr.Peek() >= 0)
                {
                    try
                    {
                        line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        var values = line.Split(new[] { separatorChar }, StringSplitOptions.None);
                        var row = table.NewRow();
                        for (var colNum = 0; colNum < values.Length; colNum++)
                        {
                            var value = values[colNum];
                            if (i == 0)
                            {
                                table.Columns.Add(value, typeof(String));
                            }
                            else
                            { row[table.Columns[colNum]] = value; }
                        }
                        if (i != 0) table.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        string cErr = ex.Message;
                        //if you need the message error
                    }
                    i++;
                }
            }
            return table;
        }
