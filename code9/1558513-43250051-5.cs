    string connectionString = "Data Source=localhost; Initial Catalog=DB_SACC; User id=sa Password=1234;";
            decimal? average;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string textt = "SELECT AVG (Total_Divida) AS 'AVG_DIVIDA' FROM t_pagamentos";
                        cmd.CommandText = textt;
                        connection.Open();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
    
                        using (DataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                average = decimal.parse(reader["AVG_DIVIDA"].ToString());
                                break;
                            }
                        }
                    }
                }
    
    
                TextBox3.Text = average.HasValue ? average.ToString() : "Unknown error occurred";
    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to retrieve the average, reason: " + ex.Message);
            }
