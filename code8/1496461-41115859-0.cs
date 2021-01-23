    protected void Button1_Click(object sender, EventArgs e)
    {
    	var val = Button1.val(); // or whatever value you want
        Response.Redirect("NewSampleMVCArea/Home/Index/?val="+ val.ToString());
    }
    
    public ActionResult Index(int year, int month)
    { 
        // year and month will be populated with the query string values
        return View(); //returns .cshtml view
    }
