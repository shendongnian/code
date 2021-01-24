    [HttpPost]
    public JsonResult DeleteTest(int id)
    {
        
        var myTableTest= db.myTable.Where(x => x.id== id).FirstOrDefault();
        db.mytable.Remove(myTableTest);
        db.SaveChanges();
        return Json(true, JsonRequestBehavior.AllowGet);
    }
