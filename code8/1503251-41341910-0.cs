    public ActionResult ExecuteProcedure()
    {
       using(var  db = new CueEntities())
       {
         var parameter = 1;
         var query =  db.Database.SqlQuery<TestProcedure>("TestProcedure @parameter1", 
                        new  SqlParameter("@parameter1", parameter)).ToList();          
            return Json(query,JsonRequestBehavior.AllowGet);     
        }
    }
