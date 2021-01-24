    public ActionResult GetAll()
    {
        using (var db=new YourModel())
        {
         List<YourType> res=db.tabelX.Where(x=>condition).ToList();
         string output = JsonConvert.SerializeObject(res);
         //or
         return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
