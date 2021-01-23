     public void UpdateCustomer(string strFName, string strFValue)
        {
            OleDbConnection mDB = new OleDbConnection();
            mDB.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data source="
                 + Server.MapPath("~/App_Data/WMA_Proj.accdb");
            mDB.Open();
            OleDbCommand cmd;
            String strSQL = "UPDATE Customers  SET cFullname= @newValue WHERE cUserId = @userId";
            cmd = new OleDbCommand(strSQL, mDB);
            cmd.Parameters.AddWithValue("@newValue", strFName);
            cmd.Parameters.AddWithValue("@userId",strFvalue);
            cmd.ExecuteNonQuery();
            UFlag = "T";
            mDB.Close();
        
        }
