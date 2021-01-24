    public void Upload()
    {
        foreach (string file in Request.Files)
        {
            var fileContent = Request.Files[file];
            if (fileContent != null && fileContent.ContentLength > 0)
            {
                var stream = fileContent.InputStream;
                var fileName = fileContent.FileName;
                //you can do anything you want here
                var path = Server.MapPath("~/SomeFolder")
                using (var newFile = File.Create(Path.Combine(path,fileName))
    			{
    			    await stream.CopyTo(newFile);
    			}
            }
        }
    
        foreach (string key in Request.Form)
        {
            var value = Request.Form[key];
        }
    }
