        public void Start(string tableName, List<ClsLink> linkList)
        {            
            DataTable table = new DataTable();
            // Getting datatable layout from database
            table = GetDataTableLayout(tableName);
            // Pupulate datatable
            foreach (ClsLink link in linkList)
            {
                DataRow row = table.NewRow();                
                //row["LinkURL"] = link.LinkURL;
                //row["CreateDate"] = link.CreateDate;
                //row["Titel"] = link.Titel;
                table.Rows.Add(row);
            }
            BulkInsertMySQL(table, tableName);
            // Enjoy
        } 
        public DataTable GetDataTableLayout(string tableName)
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Select * is not a good thing, but in this cases is is very usefull to make the code dynamic/reusable 
                // We get the tabel layout for our DataTable
                string query = $"SELECT * FROM " + tableName + " limit 0";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                };
            }
            return table;
        }
        public void BulkInsertMySQL(DataTable table, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction tran = connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = tran;
                        cmd.CommandText = $"SELECT * FROM " + tableName + " limit 0";
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.UpdateBatchSize = 10000;
                            using (MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter))
                            {
                                cb.SetAllValues = true;
                                adapter.Update(table);
                                tran.Commit();
                            }
                        };
                    }
                }
            }
        }
