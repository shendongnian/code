    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["form2"] == null && Session["form1"] == null) //show login hide signup
        {
            form1.Visible = true;
            form2.Visible = false; 
        }
        if (Session["form2"] != null && Session["form1"]==null ) //show signup hide login
        {
            form1.Visible = false;
            form2.Visible = true;
            Session["form2"] = null;
        }
        if (Session["form1"] != null && Session["form2"] == null)     //show login hide signup
        {
            form1.Visible = true;
            form2.Visible = false;
            Session["form1"] = null;
        }
    }
