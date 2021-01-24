    public ActionResult Image(string id)
    {
        var dir = Server.MapPath("/Images");
        var path = Path.Combine(dir, id + ".jpg"); //validate the path for security or use other means to generate the path.
        return base.File(path, "image/jpeg");
    }
