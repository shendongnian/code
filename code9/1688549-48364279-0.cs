    string mail="abc@hotmail.com"; 
    string name="Abdul Aleem";
    //This is In Lin Query
    string sql = "INSERT INTO Upload VALUES (@Email, @Name)" //and so on
    SqlConnection con = newSqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
    
    SqlCommand cmd = new SqlCommand(sql, con);
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.Parameters.AddWithValue("@Email", mail);
    cmd.Parameters.AddWithValue("@Name", name);
    //And same as add other paramters according to your in line query
    cmd.ExecuteNonQuery();
