    MySqlDataAdapter sda = new MySqlDataAdapter();
                        sda.SelectCommand = cmdDataBase;
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        BindingSource aSource = new BindingSource();
                        aSource.DataSource = data;
                        dataGridView1.DataSource = aSource;
                        sda.Update(data);
                        StringBuilder sb = new StringBuilder();
                        string[] columnNames = data.Columns.Cast<DataColumn>().
                                                          Select(column => column.ColumnName).
                                                          ToArray();
                        sb.AppendLine(string.Join(",", columnNames));
                        foreach (DataRow row in data.Rows)
                        {
                            string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                            ToArray();
                            sb.AppendLine(string.Join(",", fields));
                        }
                        File.WriteAllText("test.csv", sb.ToString());
