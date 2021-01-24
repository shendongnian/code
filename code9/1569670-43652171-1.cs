    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
          Logout.Visible =true;
          Login.Visible =false;
        }
        else
        {
          Login.Visible =true;
          Logout.Visible =false;
        }
    }
