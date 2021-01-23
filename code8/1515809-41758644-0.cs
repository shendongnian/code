    public int AddSholarship(string scholarshipName)
    {
    	using(var conn = new SqlConnection(....))
        {
    		string insertsql = "INSERT INTO Table1(schName) OUTPUT INSERTED.addID  values (@schName)";
    		SqlCommand cmd = new SqlCommand(insertsql,conn);
    		cmd.Parameters.AddWithValue("@schName", name);
    		var table1Id = (int)cmd.ExecuteScalar();
    		return table1Id;
    	}
    }
    
    public DataTable AddCourse(string scholarshipId, string courseName)
    {
    	using(var conn = new SqlConnection(....))
        {
    		string insertsql1 = "INSERT INTO Table2(ScholarshipID,DiplomaCourse) values (@id,@course)";
            SqlCommand cmd2 = new SqlCommand(insertsql1, conn);
            cmd2.Parameters.AddWithValue("@id", scholarshipId);
            cmd2.Parameters.AddWithValue("@course", courseName);
    
            SqlDataAdapter da = new SqlDataAdapter();
    
            da.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
    	}
    }
