    Using(SqlConnection conn = (SqlConnection)Dts.Connections["AdoNet"].AcquireConnection(Dts.Transaction)){
    if (conn.State != ConnectionState.Open){
     conn.Open;}
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = queryString;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(myDataTable);
    }
