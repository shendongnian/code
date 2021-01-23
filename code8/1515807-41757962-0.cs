    public DataTable test(string name, string course)
    {
        using(var conn = new SqlConnection(....))
        {
            string insertsql = "INSERT INTO Table1(schName) OUTPUT INSERTED.addID  values (@schName)";
            
            int tableId;
            using(var cmd = new SqlCommand(insertsql,conn))
            {
                cmd.Parameters.AddWithValue("@schName", name);
                conn.Open();
                table1Id = (int)cmd.ExecuteScalar();
            }
            string insertsql1 = "INSERT INTO Table2(ScholarshipID,DiplomaCourse)   values (@id,@course)";
            using(var cmd2 = new SqlCommand(insertsql1, conn))
            {
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
