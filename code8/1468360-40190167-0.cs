    if (!IsPostBack)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 * From homepageSelection ORDER BY postID DESC");
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;
        string messageInfo = "";
        int postIDVal = 0;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            messageInfo += reader["selectionText"].ToString();
            postIDVal = (int)reader["postID"];
        }
        con.Close();
        TextBox1.Text = messageInfo;
        postID.Value = postIDVal.ToString();
    }
