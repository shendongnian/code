    if (i == 1)
        {
            Session["admin"] = TextBox1.Text;
            Response.Redirect("add_product.aspx");
        }
        else
        {
            Label1.Text = "you have entered invalid username or password";
        }
