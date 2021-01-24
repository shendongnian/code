        [WebMethod]
        public List<string> getPaperNames(string DeviceIdString)
        {
            List<string> paperNames = new List<string>();
            string cs = ConfigurationManager.ConnectionStrings["YourConnectionStringToTheDatabase"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingPaperIds", con);
                cmd.CommandType = CommandType.StoredProcedure;
    
                SqlParameter parameter = new SqlParameter("@PaperId", PaperId);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    paperNames.Add(rdr["PaperId"].ToString());
                }
            }
    
            return paperNames;
        }
