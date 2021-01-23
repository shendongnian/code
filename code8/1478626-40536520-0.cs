        reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
