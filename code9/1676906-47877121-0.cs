    public bool Update(Classre c)
    {
        USING(SqlConnection conn = new SqlConnection(myconnstring))
    	{
    		string sql = "UPDATE Class SET ClassName = @ClassName, ClassLevel = @ClassLevel WHERE ClassID = @ClassID";
    			
    		USING(SqlCommand cmd = new SqlCommand(sql, conn))
    		{
    			cmd.Parameters.Add("@ClassName", SqlDbType.VarChar, 4000).Value = c.ClassName;
    			cmd.Parameters.Add("@ClassLevel", SqlDbType.Int).Value = c.ClassLevel;
    			cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = c.ClassID;
    			conn.Open();
    			int rows = cmd.ExecuteNonQuery();
    			return rows > 0;
    		}
    	}
    }
