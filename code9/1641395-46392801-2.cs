            public void LoadData(DataGridView grid)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn col in grid.Columns)
            {
                dataTable.Columns.Add(new DataColumn(col.Name));
            }
            string file = "mygrid.bin";
            using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int n = bw.ReadInt32();
                int m = bw.ReadInt32();
                for (int i = 0; i < m; ++i)
                {
                    dataTable.Rows.Add();
                    for (int j = 0; j < n; ++j)
                    {
                        if (bw.ReadBoolean())
                        {
                            dataTable.Rows[i][j] = bw.ReadString();
                            dataTable.Rows[i][j] = Base64Decode(dataTable.Rows[i][j].ToString());
                        }
                        else bw.ReadBoolean();
                    }
                }
            }
            grid.DataSource = dataTable;
        }
 
   
 
    
