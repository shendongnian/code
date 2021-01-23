     private void Form1_Load(object sender, EventArgs e)
            {
                connection = new SqlConnection(connectionstring);
                try
                {
                    connection.Open();
                    var q = "SELECT * FROM Lanky";
                    var query = new SqlCommand(q, connection);
                    using (var dr = query.ExecuteReader())
                    {
                        
                        ListBox1.Items.Clear();
                        while (dr.Read())
                        {
                            ListBox1.Items.Add(dr["Jménohráče"]);
                        }
                    }
                        
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex);
                }
    
            }
