    ...
        var myTable = new DataTable();
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT SourceConfig.ConfigurationId AS 'SourceID', " +
                                    "SourceConfig.Name, " +
                                    "SourceConfig.ConfigurationData AS 'SourceData', " +
                                    "TargetConfig.ConfigurationId AS 'TargetID' " +
                             "FROM ConfigurationTable SourceConfig " +
                             "LEFT JOIN ConfigurationTable TargetConfig ON " +
                                 "(TargetConfig.CustomerID = @targetCustID AND " +
                                 "SourceConfig.Name = TargetConfig.Name)" +
                             "WHERE SourceConfig.CustomerId = @sourceCustID";
                var command = new SqlCommand(sql, connection);
                command.Parameters.Add("@sourceCustID", SqlDbType.Int);
                command.Parameters.Add("@targetCustID", SqlDbType.Int);
                command.Parameters["@sourceCustID"].Value = sourceCustID;
                command.Parameters["@targetCustID"].Value = targetCustID;
                    
                var da = new SqlDataAdapter(command);
                da.Fill(myTable);
                da.Dispose();
                
                myTable.PrimaryKey = new DataColumn[1] { myTable.Columns[0] };
            }
        }
        catch (Exception e)
        {
            // Record error message
            return;
        }
        // Do stuff with 'myTable'
    ...
