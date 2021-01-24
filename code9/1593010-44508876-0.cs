    private void PopulateTable(DataTable data, string tableName)
    {
        string connectionString = @"Server=PC40808\SQLEXPRESS;Database=Scratchpad;Trusted_Connection=True;";
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction);
            copy.DestinationTableName = tableName;
            copy.WriteToServer(data);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    }
