    [HttpGet]
    public JsonResult GetMyTable(string langId)
    {
       var mytable = db.MyTables.Find(langId);
       return Json(mytable);
    }
    [HttpGet]
    public JsonResult GetMyTable(byte id, string langId)
    {
        MyTable mytable = db.MyTables.Find(id, langId);
        if (mytable == null)
        {
            return Json(new {Message = "NullreferenceExeption"})
        }
        return Json(mytable);
    }
