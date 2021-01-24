     public List<testorder> searchtes(char flag)
        {
            List<testorder> items = new List<testorder>;
            connection();
            SqlCommand cmd = new SqlCommand("SPNAME", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PstrOperationFlag", flag);
            cmd.Parameters.AddWithValue("@Pstrtestname", 'w');
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                testorder to = new testorder();
                while (sdr.Read())
                {
                    to = new testorder();
                    to.searchtest = sdr["testname"].ToString();
                    to.searchtestid = sdr["testid"].ToString();
                    items.Add(to);
    
                }
            }
            con.Close();
            return items;
        }
     
