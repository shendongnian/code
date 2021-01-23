    using (SqlConnection con = new SqlConnection(GetConnectionString())
    using (SqlCommand myCmd = new SqlCommand("sp_select_companydetails", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = "1";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }
