    protected void Button1_Click(object sender, EventArgs e)
    {
        ManagerClass managerObj = new ManagerClass();
        if(managerObj.IsValidUser(TextBox1.Text, TextBox2.Text))
        {
             Response.Redirect("page.aspx");
        }
        else
        {
             //Show message "you have not registered";
        }
    }
