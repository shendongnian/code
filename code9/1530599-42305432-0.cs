    private void Request(string request)
            {
                try
                {
                    SqlCommand command = new SqlCommand(request, connectionString);
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
    
                    if (reader.HasRows == false)
                    {
                         dataGridView1.Visible = false;
                    }
                    else
                    {
                        dataGridView1.Visible = true;
                        var dt = new DataTable();
                        dt.Load(reader);
    
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString(), e.Source.ToString());
                }
            }
