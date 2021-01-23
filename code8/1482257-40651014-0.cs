    String xConnStr=""; //connection string goes here
    SqlConnection xConn = new SqlConnection(xConnstr);
    SqlCommand sqlCmd;
    SqlDataReader sqlReader;
    string sqlCmdString = "";
    DataTable dt = new DataTable();
    
       sqlCmdString = "SELECT * from " + xNewTableName;
       sqlCmd = new SqlCommand(sqlCmdString, xConn);
       if (xConn.State == ConnectionState.Closed)
       {
            xConn.Open();
       }
       sqlReader = sqlCmd.ExecuteReader();
       dt.Load(sqlReader);
       dataGridView1.DataSource = dt;
