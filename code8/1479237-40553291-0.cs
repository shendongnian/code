    var sqlQuery = "select *
    from Customers
    where 
    (
    	state = @State
    	OR
    	@state is null
    )
    AND
    (
    	city = @City
    	OR
    	@City is null
    )";
    
    using (SqlConnection conn =  new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI"))
    {
    	conn.Open();
    	using(SqlCommand cmd = new SqlCommand(sqlQuery, conn))
    	{
            SqlParameter param  = new SqlParameter();
            param.ParameterName = "@City";
            if (string.IsNullorEmpty(city))
    		{
    			param.value = DBNull.Vale;
    		}
    		else
    		{
    			param.Value = city;
    		}
            cmd.Parameters.Add(param);
            
    		SqlParameter param  = new SqlParameter();
            param.ParameterName = "@State";
            if(string.IsNullorEmpty(state))
    		{
    			param.value = DBNull.Vale;
    		}
    		else
    		{
    			param.Value = state;
    		}
            cmd.Parameters.Add(param);
           }
    
    	}
    }
