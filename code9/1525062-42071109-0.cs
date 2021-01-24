    string connectionString = ConfigurationManager.ConnectionStrings["OnlineDBContext"].ToString();
    
    using (SqlConnection con = new SqlConnection(connectionString))
    {
    
        SqlCommand cmd = new SqlCommand("spAddOrganization", con);
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
    
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@Organizational_Number", organize.Organizational_Number),
            new SqlParameter("@Location", organize.Location),
            new SqlParameter("@Organizational_Address", organize.Organization_Address),
            new SqlParameter("@TelephoneNo_Org", organize.TelephoneNo_Org),
            new SqlParameter("@Organizational_Name", organize.Organizational_Name),
            new SqlParameter("@Administrator_Name", organize.Administrator_Name)
        };
        cmd.Parameters.AddRange(parameters);
        int retorno = cmd.ExecuteNonQuery();
    }
