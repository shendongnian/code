    string image = "";
    if (FileUpload1.HasFile==true)
    {
        string str = FileUpload1.FileName;
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/userimage/" + str));
        image  = "~/userimage/" + str.ToString();
    }
    string name = username_textbox.Text;
    string email = email_textbox.Text;
    string pass = password_textbox.Text;
    String connString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
    using (SqlConnection con = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand("insert into Register values(@Username,@Email,@Password,@ImageData)", con);
        cmd.Parameters.AddWithValue("@Username", name);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Password", pass);
        cmd.Parameters.AddWithValue("@ImageData", FileUpload1.HasFile ? image: DbNull.Value);
        con.Open();
        cmd.ExecuteNonQuery();       
    }
    lblMsg.Text = "Înregistrare cu succes";
    Response.AddHeader("REFRESH", "2;URL=login.aspx");
          
