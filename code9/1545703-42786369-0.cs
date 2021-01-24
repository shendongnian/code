    public DataTable getfeechallan(Bal b)
        {
            SqlDataAdapter sdb = new SqlDataAdapter("Select count(*) From reserve", con);
            DataTable dt = new DataTable();
            List<string> dc = new List<string>();
    
            sdb.Fill(dt);
    
            foreach (DataRow dd in dt.Rows)
            {
               dc.Add(dd["ftid"].ToString());
            }
    
            Bal.abc = dc;
    
            return dt;
        }
