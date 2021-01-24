    if (con.State == ConnectionState.Open)
    {
        con.Close();
    }
    con.Open();
    
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    //All you want is the member Id why get all the columns 
    cmd.CommandText = "SELECT top 1 MemberId FROM Medleminfo ORDER BY MemberId desc";
    
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        last_id = Convert.ToInt32( reader[0]));
    }
    return last_id;
