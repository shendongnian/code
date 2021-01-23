     public class CommonConnection
    {
        String constr = System.Configuration.ConfigurationManager.ConnectionStrings["myconectionstring"].ConnectionString;
        public CommonConnection()
    	{
           
    		//
    		// TODO: Add constructor logic here
    		//
    	}
        //Insert,Update,Delete....
        public int ExecuteNonQuery1(string str)
        {
            //String constr = System.Configuration.ConfigurationManager.ConnectionStrings["CommonConnection"].ConnectionString;
    
            SqlConnection con = new SqlConnection(constr);
    
            SqlCommand cmd = new SqlCommand(str, con);
    
    
            int result = 0;
    
            try
            {
    
                con.Open();
                result = cmd.ExecuteNonQuery();
    
    
                con.Close();
            }
            catch (Exception ex)
            {
                result = -1;
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex2)
                {
                    // ErrHandler.WriteError(ex2.ToString());
                }
                // ErrHandler.WriteError(ex.ToString());
            }
    
            return result;
    
        }
    }
