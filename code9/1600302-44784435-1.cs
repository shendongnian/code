    var query = "INSERT INTO Skills(SkillName, SkillNumber, SkillLastUpdated, SkillServer) 
    			 VALUES (@SkillName, @SkillNumber, @SkillLastUpdated, @SkillServer)";
        
    using (SqlConnection connection = new SqlConnection(SQLHelper.CnnCal("CQDB")))
    {
    	using(SqlCommand cmd = new SqlCommand(query, connection))
    	{
    	    // add parameters and their values
    	    // edit as appropriate
    	    cmd.Parameters.Add("@SkillName", System.Data.SqlDbType.NVarChar, 100).Value = skills.SkillName;
    
    	    //etc....
    	    
    	    cn.Open();
    	    cmd.ExecuteNonQuery();
    	}    
    }
