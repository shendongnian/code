    [HttpPost]
    public IActionResult uploadFile()
    {
		var files = Request.Files;
		if (Request.Form[0] == null || files[0] == null || files[0].ContentLength < 1)
        {
                // TODO log
                Response.StatusCode = 400;
                return Json("Please provide a file");
        }
    	// TODO parse the file(s) as you like :)
	}
