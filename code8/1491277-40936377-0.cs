	protected void button_sign_Click(object sender, EventArgs e)
	{
		object Image;
		if (FileUpload1.HasFile==true)
		{
			string str = FileUpload1.FileName;
			FileUpload1.PostedFile.SaveAs(Server.MapPath("~/userimage/" + str));
			Image = "~/userimage/" + str.ToString();
		}
		else {
			Image = System.DBNull.Value;
		}
		
		string name = username_textbox.Text;
		string email = email_textbox.Text;
		string pass = password_textbox.Text;
		String CS = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
		using (SqlConnection con = new SqlConnection(CS))
		using(SqlCommand cmd = new SqlCommand("insert into Register values(@Username,@Email,@Password,@ImageData)", con))
		{
			cmd.Parameters.AddWithValue("@Username", name);
			cmd.Parameters.AddWithValue("@Email", email);
			cmd.Parameters.AddWithValue("@Password", pass);
			cmd.Parameters.AddWithValue("@ImageData", Image);
			con.Open();
			cmd.ExecuteNonQuery();
			lblMsg.Text = "Înregistrare cu succes";
			Response.AddHeader("REFRESH", "2;URL=login.aspx");
		}
