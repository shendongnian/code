    Label1.Text = string.Empty;
    SqlConnection con1 = new SqlConnection(strConnString);
    con.Open();
    str = "select food from foodName where id= 1";
    com = new SqlCommand(str, con);
    
    SqlDataReader reader = com.ExecuteReader();
    while (reader.Read())
    {
        Label1.Text += reader["food"].ToString();
    }
    con.Close();
