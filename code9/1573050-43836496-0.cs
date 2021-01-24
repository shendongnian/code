        SqlConnection myADONETConnection;
        myADONETConnection = (SqlConnection)(Dts.Connections["DBConn"].AcquireConnection(Dts.Transaction) as SqlConnection);
        If (myADONETConnection.State != ConnectionState.Open){
            myADONETConnection.Open();
        }
		
		string queryString =
        "SELECT * from " + TableName;
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, myADONETConnection);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
