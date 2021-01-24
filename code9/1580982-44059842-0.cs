    public string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["CHTproductionConnectionString"].ConnectionString;
        }
    }
    public DataTable GetDataTableFromSproc(string sproc, SqlParameter[] parameters)
    {
        using (SqlConnection con = new SqlConnection(this.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(sproc, con) { CommandType = CommandType.StoredProcedure })
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            con.Open();
            cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
