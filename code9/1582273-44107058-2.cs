     public  Object getVoteridof(String username,String password)
            {
                Object returnValue;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ArtConnectionString"].ConnectionString.ToString()))
                {
    
    
    
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select VoterID from tbl_voter where Uname=@param1 and Pword=@param2";
                    cmd.Parameters.AddWithValue("@param1", username);
                    cmd.Parameters.AddWithValue("@param2", password);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
    
                    returnValue = cmd.ExecuteScalar();
                }
    
                return returnValue;
            }
