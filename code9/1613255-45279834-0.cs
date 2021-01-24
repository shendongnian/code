    List<string> tableNames = new List<string>();
    try
    {
        // Open connect to access db
        sourceConn.Open();
        // Build table names list from schema
        foreach (DataRow row in sourceConn.GetSchema("Tables").Select("table_type = 'TABLE'"))
            tableNames.Add(row["table_name"].ToString());                
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        if(sourceConn.State != ConnectionState.Closed)
            sourceConn.Close();
    }
    
    foreach (string table in tableNames)
    {
        //Get all table data from Access
        string query = string.Format("SELECT * FROM {0}", table);
        DataTable accessTable = new DataTable(table);
        try
        {
            sourceConn.Open();
            System.Data.OleDb.OleDbCommand accessSqlCommand = new System.Data.OleDb.OleDbCommand(query, accessConn);
            System.Data.OleDb.OleDbDataReader reader = (System.Data.OleDb.OleDbDataReader)accessSqlCommand.ExecuteReader();
            // Load all table data into accessTable
            accessTable.Load(reader);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            if(sourceConn.State != ConnectionState.Closed)
                sourceConn.Close();
        }
                
        // Import data into MySQL
        accessTable.AcceptChanges();
        // The table should be empty, so set everything as new rows (will be inserted)
        foreach (DataRow row in accessTable.Rows)
            row.SetAdded();
        
        try
        {
            destConn.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(query, mySqlConn);
            MySql.Data.MySqlClient.MySqlCommandBuilder cb = new MySql.Data.MySqlClient.MySqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            // Update the destination table 128 rows at a time
            da.UpdateBatchSize = 128;
            // Perform inserts (and capture row counts for output)
            int insertCount = da.Update(accessTable);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if(destConn.State != ConnectionState.Closed)
                destConn.Close();
        }
    }
