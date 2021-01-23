    public int ExecuteQuery(string strQuery, Int16 TimeOut = 30)
        {
            int RecordsAffected;
            SqlCommand cmd;
            try
            {   
                cnOpen(); 
                cmd = new SqlCommand(strQuery, Conn);
                cmd.CommandTimeout = TimeOut;
                Conn.Open();    //Add this here
                RecordsAffected = cmd.ExecuteNonQuery();
    
                return RecordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnClose();
                cmd = null;
            }
        }        
    }
    
            
