    public ActionResult Beacon(string value) {
        var dir = Server.MapPath("/Content/Images/Sprites/");
        var path = Path.Combine(dir, "logo.png");
        var theFile = new FileInfo(path);
        if (theFile.Exists) {
            return File(System.IO.File.ReadAllBytes(path), "image/png");
        }
        return this.HttpNotFound();                
    }
