    List<tmp_WatchList> data = new List<tmp_WatchList>();
    
    using (SqlConnection con = new SqlConnection(conStr))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand("sp_CheckPersonList", con)) 
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            SqlDataReader oReader = cmd.ExecuteReader();
            while (oReader.Read())
            {
                tmp_WatchList l = new tmp_WatchList();
                l.id = int.Parse(oReader["id"].ToString());
                l.Name = oReader.GetValue(1).ToString();
                l.Crime = int.Parse(oReader.GetValue(2).ToString());
                data.Add(l);
            }
        }
    }
