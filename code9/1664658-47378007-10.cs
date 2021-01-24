    public ActionResult Index()
    {
       var houses = db.Houses
                      .Select(a=>new HouseViewModel 
                                      { HouseId =a.HouseId,
                                        HoueseName =a.HouseName,
                                        StreetName = a.Street.StreetName
                                      })
                      .ToList();
       return View(houses);
    }
