    public JsonResult GetResults(string name) //Here is the name parameter
    {
       MainEntities db = new MainEntities(); //Db context
         
       var con = (from c in db.TableName
                  where c.ColumnName == name //Pass the name parameter in the query
                  select c).ToList();
       return Json(con); //Finally returns the result in Json
    }
