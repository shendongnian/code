    public ActionResult Index()
    {
       var list= new List<HouseViewModel>{
                   new HouseViewModel { HouseId =1,HoueseName ="Abc", StreetName ="Detroit"},
                   new HouseViewModel { HouseId =2,HoueseName ="Xyz", StreetName ="Novi"}
       };
       return View(list);
    }
