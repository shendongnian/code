    public void WriteToCsv(DataTable table, string path, int size)
            {
                int fileNumber = 0;
                StreamWriter sw = new StreamWriter(string.Format(path, fileNumber), false);
                //headers  
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sw.Write(table.Columns[i]);
                    if (i < table.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
    
                foreach (DataRow row in table.AsEnumerable())
                {
                    sw.WriteLine(string.Join(",", row.ItemArray.Select(x => x.ToString())));
                    if (sw.BaseStream.Length > size) // Time to create new file!
                    {
                        sw.Close();
                        sw.Dispose();
                        fileNumber ++;
                        sw = new StreamWriter(string.Format(path, fileNumber), false);
                    }
                }
    
                sw.Close();
            }
