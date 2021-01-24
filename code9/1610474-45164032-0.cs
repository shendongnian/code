    public Section SectionView(object id, SqlConnection conn, string sql = String.Empty)
    {
        if (!String.IsNullOrEmpty(sql))
        {
            if (conn.State == ConnectionState.Closed) conn.Open();                
            
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@sectionID", id.ToString);
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataAdapter da = new SqlDataAdapter
                    { SelectCommand = cmd };
    
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                return id;
            }
        }
    }
