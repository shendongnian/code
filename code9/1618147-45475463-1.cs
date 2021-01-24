    try
        {
             SqlConnectionStringBuilder _connectionString = new SqlConnectionStringBuilder();
             _connectionString.DataSource = @".\SQLEXPRESS";
             _connectionString.InitialCatalog = "databaseName"; //add database name which created dynamically 
             _connectionString.IntegratedSecurity = true;
             
        }
    catch(Exception ex)
            {
                MessageBox.Show("Not able to create connection string. Error : " +ex);
            }
