    private void lbxFSR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try //For ePN
        {
            //This is where I need the help <--------------------
            // Break the operation into two parts
            // The ODBC & SQL databases can't talk directly to each other.
            // 1. Download ODBC table into your C# DataTable
            DataTable dt;
            epnConnection.Open();
            string epnQuery =   "SELECT FNCL_SPLIT_REC_ID, PROJ_ID, SALES_SRC_PRC " + 
                                "FROM PROJ_FNCL_SPLIT " + 
                                "WHERE PROJ_ID='" + lbxFSR.Text + "'";
            OdbcCommand epnCommamd = new OdbcCommand(epnQuery, epnConnection);
            epnCommamd.CommandTimeout = 0;
            OdbcDataReader dr = epnCommamd.ExecuteReader();
            dt.Load(dr);
            epnConnection.Close();
            // 2. Upload your C# DataTable to the SQL table
            // This select query tells the SqlDataAdapter what table you want to work with, on SQL database
            // The WHERE 0 = 1 clause is to stop it returning any rows, 
            // however you still get the column names & datatypes which you need to perform the update later
            string selectQuery = "SELECT FNCL_SPLIT_REC_ID, PROJ_ID, SALES_SRC_PRC " +
                                " FROM PROJ_FNCL_SPLIT WHERE 0 = 1";
            tempDbConnection.Open();
            var da = new SqlDataAdapter(selectQuery, tempDbConnection);
            var commandBuilder = new SqlCommandBuilder(da);
            // The DataAdapter's `Update` method applies the contents of the DataTable `dt` to the table specified in the `selectQuery`.
            // It does this via the SqlCommandBuilder, which knows how to apply updates to a Sql Database.
            da.Update(dt);                                      // Channel the C# DataTable through the DataAdapter
            tempDbConnection.Close();
        }
        catch (Exception ex)
        {
            epnConnection.Close();
            tempDbConnection.Close();
            MessageBox.Show("Error " + ex);
        }
    }
