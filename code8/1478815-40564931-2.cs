    var conn = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
    string SQL1 = "INSERT INTO tbl_cust(cust_id,cust_name) values ('000001','YoungMcD') ";
    string SQL2 = "UPDATE tbl_cust SET custname='OldMcDonald' WHERE cust_id='000001'";
    using (SqlConnection connection = new SqlConnection(conn))
    {
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        SqlTransaction transaction;
        transaction = connection.BeginTransaction();
    
        try
        {
            command.CommandText = SQL1;
            int rowsAffected = command.ExecuteNonQuery();
            command.CommandText = SQL2;
            rowsAffected += command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex1)
        {
            // Attempt to roll back the transaction.
            try
            {
                transaction.Rollback();
            }
            catch (Exception ex2)
            {
                // This catch block will handle any errors that may have occurred
                // on the server that would cause the rollback to fail, such as
                // a closed connection.
            }
        }
    }
