    using (OracleConnection cn = new OracleConnection("con string"))
    {
        cn.Open();
        OracleCommand cmd = new OracleCommand("ADD_USER");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = cn;
        cmd.Parameters.AddWithValue(@YourSPParamName1, txtName.Text);
        cmd.Parameters.AddWithValue(@YourSPParamName2, txtName2.Text);
        cmd.Parameters.AddWithValue(@YourSPParamName3, txtID.Text);
        cmd.ExecuteNonQuery();
    }
