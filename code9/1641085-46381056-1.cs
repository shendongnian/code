    Session["Parameter"] = datatable.Rows[0].Field<string>(1); 
    // Set a break point at Redirect, and check to make value is assigned 
    // to Session["Parameter"] before redirecting.
    Response.Redirect("Welcome.aspx");
    
    protected void Page_Load(object sender, EventArgs e)
    {
       Label2.Text = Session["Parameter"] + ", welcome to the website!"; 
    }
