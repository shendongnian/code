    string id;
 
            for (int i = 0; i < dataGridView1.RowCount; i++)   {
            String path = "\\registros.csv";
 
            List<String> lines = new List<String>();
 
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line;
 
                    while ((line = reader.ReadLine()) != null)
                    {
                        id = (string)dataGridView1.Rows[i].Cells[2].Value;
                        if (line.Contains(","))
                        {
 
                            String[] split = line.Split(',');
 
                            if (split[1].Equals(id) && (bool)dataGridView1.Rows[i].Cells[0].FormattedValue == true)
                            {
                     
                                split[10] = "" + 1;
                                line = String.Join(",", split);
 
                            }
 
                            if (split[1].Equals(id) && (bool)dataGridView1.Rows[i].Cells[0].FormattedValue == false) 
                            {
                   
                                split[10] = "" + 0;
                                line = String.Join(",", split);
 
                            }
 
                        }
                        lines.Add(line);
                    }
 
                }
 
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }
        }
