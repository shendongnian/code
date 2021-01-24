    private DataTable GetData(string query, params SqlParameter[] parameters)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["tlcString"].ConnectionString;
    
        //You can stack these up
        using (SqlConnection con = new SqlConnection(constr))
        using (SqlCommand cmd = new SqlCommand(query, con))
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            foreach(var p in parameters)
                cmd.Parameters.Add(p);
             sda.Fill(dt);
        }
        return dt;
    }
