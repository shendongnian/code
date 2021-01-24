    [HttpPost]
    public ActionResult Index(string k)
    {      
        var stream = Request.InputStream;
        string value = string.Empty;
        using (var reader = new StreamReader(stream))
        {
            value = new StreamReader(stream).ReadToEnd();
        }
        Debug.WriteLine(String.Format("Result: {0};", value));
        return Json(new { data =  value}, JsonRequestBehavior.DenyGet);
    }
