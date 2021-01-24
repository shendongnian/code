    OleDbConnection oleConn = new OleDbConnection();
    public DataTable GetQueryString(string strQuery)
        {
            OleDbDataAdapter sqlAdapter = new OleDbDataAdapter();
            DataTable dttData = new DataTable();
            using (oleConn = new OleDbConnection("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;"))
            {
                sqlAdapter.SelectCommand = new OleDbCommand(strQuery, oleConn);
                sqlAdapter.Fill(dttData);
                oleConn.Close();
                oleConn.Dispose();
            }
            return dttData;
        }
