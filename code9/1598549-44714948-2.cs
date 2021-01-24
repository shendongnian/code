    public ActionResult Index()
    {
    
            using (var context = new QuotingEngineEntities1())
            {
    
                var vehicle = from s in context.fn_GetVehicle(description)
                               select new
                               {
                                   s.MAKE,
                                   s.MODEL,
                                   s.PRICE,
                                   s.POWER,
                                   s.Transmission
                               };
                dynamic yourmodel = new ExpandoObject(); 
                yourmodel.Vehicles = vehicle.ToList();
    
            }
  
    
            return View(yourmodel);
    }
