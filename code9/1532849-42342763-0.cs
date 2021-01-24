    using (OleDbConnection thisConnection = new OleDbConnection(connectionname))
    {
        string deletequery = @"DELETE FROM DATA WHERE [Name] = @name And 
                             [Date] = @date";
        OleDbCommand myAccessCommandDelete = new OleDbCommand(deletequery, thisConnection);
        thisConnection.Open();
        myAccessCommandDelete.Parameters.Add("@name", OleDbType.VarWChar).Value = "A";
        myAccessCommandDelete.Parameters.Add("@date", OleDbType.Date).Value = new DateTime(2017,1,1);
        myAccessCommandDelete.ExecuteNonQuery();
        // not needed -> thisConnection.Close();
    }
