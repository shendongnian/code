    var con = new SqlConnection("your connection string goes here");
    SqlCommand cmd = new SqlCommand("SELECT * FROM Members where Username= 'usr' and Password= 'pwd'", con);
    bool result = false;
    cmd.Connection.Open();
    using (cmd.Connection)
    {
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
            result = true;
    }
    if (result == true)
        // Login successful
    else
        // Login failed
