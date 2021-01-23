    string cmdText = "SELECT Role FROM Login WHERE Username = @name AND Password = @pass";
    // You already know the username
    string username = textBox1.Text;
    string role = "";
    using (SqlCommand SelectCommand = new SqlCommand(cmdText, connectionstring))
    {
        connectionstring.Open();
        SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
        SelectCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = textBox2.Text;
        SqlDataReader myReader;
        
        using(SqlDataReader myReader = SelectCommand.ExecuteReader())
        {
            while (myReader.Read())
            {
                role = myReader["Role"].ToString();
            }
        }
        Response.Redirect(role.Trim() + ".aspx");
    }
