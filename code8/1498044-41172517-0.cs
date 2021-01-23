    [HttpPost]
    public JsonResult MyMethod () {
        Stream req = Request.InputStream;
        req.Seek(0, System.IO.SeekOrigin.Begin);
        string json = new StreamReader(req).ReadToEnd();
        MyModel model = JsonConvert.DeserializeObject<MyModel>(json);
        // use model...
    }
