    int i;
    con.Open();
    SqlCommand cmd1 = con.CreateCommand();
    cmd1.CommandType = CommandType.Text;
    cmd1.CommandText = "select count(*) from admin_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' ";
    i = cmd1.ExecuteScalar();
    if (i == 1)
    {
        Session["admin"] = TextBox1.Text;
        Response.Redirect("add_product.aspx");
    }
    else
    {
        Label1.Text = "you have entered invalid username or password";
    }
    con.Close();
