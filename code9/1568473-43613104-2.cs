    protected void BtnStap1_Click(object sender, EventArgs e)
    {
    	con.Open();
    	SqlCommand cmd = con.CreateCommand();
    	cmd.CommandType = CommandType.Text;
    	var paramsList = new SqlParameter[]
    	{
    		new SqlParameter("@p1", RandomID),
    		new SqlParameter("@p2", Voornaamtxt.Text),
    		new SqlParameter("@p3", Tussenvoegseltxt.Text),
    		new SqlParameter("@p4", Achternaamtxt.Text),
    		new SqlParameter("@p5", string.Join(" ",Emailtxt.Text,Niveautxt.Text),
    	};
    	cmd.CommandText = "insert into Gebruiker values(@p1, @p2, @p3, @p4, @p5)";
    	cmd.Parameters.AddRange(paramsList);
    	cmd.ExecuteNonQuery();
    	con.Close();
    	MessageBox.Show(RandomID.ToString(), Notification);
    	Response.Redirect("/Webpages/LoginPage.aspx");
    }
