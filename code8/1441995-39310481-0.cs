    [HttpGet]
    public ActionResult Get(string id)
    {
       var path = $@"d:\smth\upload\{id}.jpeg";
       byte[] bytes = System.IO.File.ReadAllBytes(path);
       return File(bytes, "image/jpeg");
    }
