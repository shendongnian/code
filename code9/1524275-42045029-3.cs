    [HttpPost]
    public ActionResult Index(HttpPostedFileBase[] files)
    {
    	try
    	{
    		foreach (HttpPostedFileBase file in files)
    		{
    			string name = System.IO.Path.GetFileName(file.FileName);
    			file.SaveAs(Server.MapPath("~/Images/" + name));
    			
    			string filename = "Images/" + name;
    			
    			//Save the the filename to your database
    		}
    	}
    	catch
    	{
    		throw ex;
    	}
    	return View();
    }
