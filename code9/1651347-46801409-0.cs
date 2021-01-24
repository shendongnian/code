    public static bool UpdateTiger(Tiger p)
    {
        var command = new SqlCommand();
        command.CommandText = "UPDATE Owner SET Tiger1=@tiger1 WHERE Personnummer=@perNum";
    
        command.Parameters.AddWithValue("@tiger1", p.tiger1).Direction = ParameterDirection.Input;
        command.Parameters.AddWithValue("@pernum", p.pernum).Direction = ParameterDirection.Input;
    
        try
        {
            SqlHelper.ExecuteNonQuery(command); // this is where I run the procedure
            return true;
        }
        catch (Exception e)
        {
    
            return false;
        }
