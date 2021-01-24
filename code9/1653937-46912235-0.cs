    private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conf.connection_string))
            {
                if (OpenConnection(connection))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = string.Format("SELECT * FROM {0}", privateCustomerTablename);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            using (DataTable schemaTable = reader.GetSchemaTable())
                            {
                                columnList.Clear();
                                foreach (DataRow row in schemaTable.Rows)
                                {
                                    columnList.Add(row.Field<String>("ColumnName"));
                                }
                            }
                        }
                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd.CommandText, connection))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                dataAdapter.Fill(dt);
                                e.Result = dt;
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }
