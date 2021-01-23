    public ActionResult Beacon(string value) {
    var path =  Server.MapPath(Url.Content("~/Content/Images/Sprites/")) + "logo.png";
    var theFile = new FileInfo(path);
    if (theFile.Exists) {
        return File(System.IO.File.ReadAllBytes(path), "image/png");
        //or return base.File(path, "image/png");
    }
        return this.HttpNotFound();                
    }
