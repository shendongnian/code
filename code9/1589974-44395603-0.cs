    public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
    {
        foreach (var file in files)
        {
    		fs = new FileStream(image_url, FileMode.Open, FileAccess.Read);    
    		img = Image.FromStream(fs);  
            var image = Image.FromStream(fs);
            ...
    		
    		//after you are done call below line
    		fs.Close();
        }
    }
