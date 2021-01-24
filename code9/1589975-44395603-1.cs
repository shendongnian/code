    public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
    {
        foreach (var file in files)
        {
    		using (FileStream stream = File.Open(<give_file_URL_here>, FileMode.Open))
    		{
    			var image = Image.FromStream(stream);
    			//...
    		}
        }
    }
