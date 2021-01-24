    public int Save_Del_Up(string query)
         try
            {    
                con.Open();
                cmd = new SqlCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
        
                return result;
        } catch (Exception ex) {
            return -1;
        }
    }
