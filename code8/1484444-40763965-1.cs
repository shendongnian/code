    SqlDataReader reader = cmd.ExecuteReader();
    
                if (reader.HasRows)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                reader.Close();
    
                return result;
