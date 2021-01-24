    protected void Login_Click(object sender, EventArgs e)
    {
       Session["UserName"] = UserName; //Assign user name
       Login.Visible =true;
       Logout.Visible =true;
    }
