    public JsonResult GetResults(string name)
    {
         MainEntities db = new MainEntities();
         
         var con = (from c in db.TableName
                            where c.ColumnName == name
                            select c).ToList();
         return Json(con);
    }
