    public DataTable test(string name, string course)
    {
        using(var conn = new SqlConnection(....))
        {
            string insertsql = "INSERT INTO Table1(schName) OUTPUT INSERTED.addID  values (@schName)";
            
            cmd.Parameters.AddWithValue("@schName", name);
            conn.Open();
            var table1Id = (int)cmd.ExecuteScalar();
            
            string insertsql1 = "INSERT INTO Table2(ScholarshipID,DiplomaCourse)   values (@id,@course)";
            
            cmd2.Parameters.AddWithValue("@id", table1Id);
            cmd2.Parameters.AddWithValue("@course", course);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
