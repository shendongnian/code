    public class MyModel {
        public string Name { get; set; }
        public string Id { get; set; }
        public string CountryID { get; set; }
        public string CountryName { get; set; }
    }
    public IList<MyModel> GetAccessors()
    {
        var xx = from n in db.Accessors
                 join cn in db.Countrys on n.CountryID equals cn.CountryID
                 select new MyModel 
                 {
                     Name = n.Name,
                     Id = n.Id,
                     CountryID = n.CountryID,
                     CountryName = cn.CountryName
                 };
        return xx.ToList();
    }
    public JsonResult tt()
    {
         var  sss=  objrepo.GetAccessors();
        return Json(sss, JsonRequestBehavior.AllowGet);
    }
