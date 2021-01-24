        public void checkTableExists()
        {
            connectionString = @" 
            Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\keith_000\Documents\ZuriRubberDressDB.mdf;
            Integrated Security=True;
            Connect Timeout=30";
            string tblName = @"BasicHours";
            string str = @"IF EXISTS(
                    SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_NAME = @table) 
                    SELECT 1 ELSE SELECT 0";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(str, connection))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(str, connection);
                        cmd.Parameters.Add("@table", SqlDbType.NVarChar).Value = tblName;
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists == 1)
                        {
                            MessageBox.Show("Table exists");
                        }
                        else
                        {
                            MessageBox.Show("Table doesn't exists");
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sql issue");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Major issue");
            }
        }
