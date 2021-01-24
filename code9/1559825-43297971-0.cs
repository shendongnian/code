    [HttpPost]
    public ActionResult AddItems(FormCollection form)
    {
        //...other code removed for brevity
    
        byte[] bytes;
        var files = Request.Files;
        if(files.Count > 0) {
            var stream = files[0].InputStream;
            //Get image data from stream and stored in bytes
            using(var memoryStream = new MemoryStream()) {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
        } else {
            //...Set default image data.
            var filename = this.HttpContext.Server.MapPath("~/Content/Images/default-artwork.png");
            bytes = System.IO.File.ReadAllBytes(filename);
        }
        //Assuming a property to hold the image data byte[] AlbumArt { get; set; }
        i.AlbumArt = bytes;
        DAL.AddItems(i);
        //...other code removed for brevity
    }
