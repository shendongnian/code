    [WebMethod]
            public static List<string> GetCompanyData(string companyname)
        {
            List<string> result = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
    
            
            SqlCommand cmd = new SqlCommand("[searchCompanyName]", con);
            cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@companyname", companyname);
                    SqlDataReader dr = cmd.ExecuteReader();
    
                    while (dr.Read())
                    {
                        result.Add(dr["companyname"].ToString());
                    }
                    return result;
            }
