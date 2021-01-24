    protected void post(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName== "comment")
        {
            //Find TextBox Control
            TextBox txt = (TextBox)e.Item.FindControl("txtcomment");
            var sno = e.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(strconn);
            SqlCommand com = new SqlCommand();
            com.CommandText = "INSERT INTO Comments(Sno,Comment,Username) VALUES (@SNO, @COMMENT, @USERNAME)";
            com.Connection = con;
            //Add Command Parameters
            com.Parameters.AddWithValue("@SNO", sno);
            com.Parameters.AddWithValue("@COMMENT", txt.Text);
            com.Parameters.AddWithValue("@USERNAME", username);
            con.Open();
            //Execute Command
            com.ExecuteNonQuery();
        }
    }
