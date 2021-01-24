    SqlConnection con = new SqlConnection("YourConnection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    cmd = new SqlCommand("get_values", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@Id2", id); // if you have parameters.
    da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    con.Close();
    // ds.Tables[0] your first select statement
    // ds.Tables[1] your second select statement
