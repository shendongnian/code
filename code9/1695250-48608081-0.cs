    public IActionResult GetDocuments()
    {
        var documents = ...;
        var options = new JsonSerializerSettings 
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        return Json(documents, options);
    }
