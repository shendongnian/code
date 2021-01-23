    public IEnumerable<Tuple<string,string>> GetData()
    {
        List<Tuple<string,string> results = new List<Tuple<string,string>>();
        using (SqlConnection con = new SqlConnection(this.Connection))
        {
            con.Open();
            SqlCommand command = new SqlCommand("Select TITTLE,VALUE from T_PROJECTS ", con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                    results.add(new Tuple<string,string>(reader["TITLE"].ToString(),reader["VALUE"].ToString()));
            }
            return results;
        }
    }
