        using (SqlConnection con = new SqlConnection(constr))
        {
            
            FileInfo file = new FileInfo(DIRECTORY OF THE SCRIPT);
            string script = file.OpenText().ReadToEnd();
         
            SqlCommand command = new SqlCommand(script, con);
            command.CommandType = CommandType.Text;
            try
            {
                con.Open();
                string rowsAffected =(string) command.ExecuteScalar();
                Display( rowsAffected);
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Display(ex.Message);
            }
        }
