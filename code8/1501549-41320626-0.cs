        //I have already Made the Connection and this is the Function/Method for the Class
        public Dictionary<string, string[]> Select(string query, List<MySqlParameter> Values)
        {
            //Open connection
            if (connectionstatus == true)
            {
                //MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                foreach (MySqlParameter param in Values)
                {
                    cmd.Parameters.Add(param);
                }
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Dictionary<string, string[]> data = new Dictionary<string, string[]>();
                var table = new DataTable();
                do
                {
                    table.Load(dataReader);
                } while (!dataReader.IsClosed);
                var columns = table.Columns.Cast<DataColumn>()
                 .Select(x => x.ColumnName)
                 .ToList();
                var totalrownum = table.Rows.Count;
                string[][] values = new string[columns.Count][];
                for (int i = 0; i < columns.Count; i++)
                {
                    values[i] = new string[totalrownum];
                }
                for (int column = 0; column < columns.Count; column++)
                {
                    for (int i = 0; i < totalrownum; i++)
                    {
                        values[column][i] = table.Rows[i][column].ToString();
                    }
                    data.Add(columns[column], values[column]);
                    Console.WriteLine(columns[column]);
                }
                //close Data Reader
                dataReader.Close();
                return data;
            }
            else
            {
                Dictionary<string, string[]> data = new Dictionary<string, string[]>();
                return data;
            }
        }
