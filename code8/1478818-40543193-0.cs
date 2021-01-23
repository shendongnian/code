    public DataSet _JoinRoomSubPayment(string user){
    conn.Open();
    SqlCommand cmd = new SqlCommand("JoinRoomSubPayment", conn);
    cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = user;
    // cmd.ExecuteNonQuery(); remove this line from your code 
    cmd.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    ds.Clear();
    da.Fill(ds, "_JoinRoomSubPayment");
    conn.Close();
    return ds;}
