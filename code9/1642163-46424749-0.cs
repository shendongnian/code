    con.Open();
    SqlCommand cmd1 = con.CreateCommand();
    cmd1.CommandType = CommandType.Text;
    cmd1.CommandText = "select * from admin_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "' ";
    cmd1.ExecuteNonQuery();
    DataTable dt1 = new DataTable();
    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
    da1.Fill(dt1);
    i = Convert.ToInt32(dt1.Rows.Count.ToString());
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
