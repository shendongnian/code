    using (SqlConnection conn = new SqlConnection("MyString"))
    using (SqlCommand cmd = conn.CreateCommand())
    {
        cmd.CommandText = string.Format("sp_detach_db '{0}', 'true'", myDatabaseName); /* where myDatabaseName is a string */
        cmd.CommandType = CommandType.Text;
    
    
        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParameter.Direction = ParameterDirection.ReturnValue;
    
        conn.Open();
        cmd.ExecuteNonQuery();
        object result = returnParameter.Value;
        int resultInt = Convert.ToInt32(result);
        if( 0 != resultInt )
        { throw new ArgumentOutOfRangeException("detach failed");}
    }
