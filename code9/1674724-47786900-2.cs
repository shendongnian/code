    [HttpPost]
    public JsonResult AutoComplete(string keyword)
    {
        using (DatabaseEntities entities = new DatabaseEntities())
        {
            var records = entities.AutoComplete_Search(keyword).ToList();
            return Json(records);
        }
    }
