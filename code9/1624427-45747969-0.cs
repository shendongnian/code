    for (int i = 0; i < (dataGridView2.Rows.Count)-1; i++)
                {
                    StrQuery = "insert into branch1_orders values("
                        + order_num + ","
                        + dataGridView2.Rows[i].Cells["number"].Value + ","
                        + dataGridView2.Rows[i].Cells["price"].Value + ")";
                    command.CommandText = StrQuery;
                    command.ExecuteNonQuery();
    
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e2)
                    {
                        MessageBox.Show(e2.Message);
                    }
                } 
