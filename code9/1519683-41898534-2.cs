    public ActionResult Index()
        {
           TestModel test = new TestModel();
           List<Bike> bikes = new List<Bike>();
           Bike bike1 = new Bike
           {
               Name = "Yeti",
               type = "Mountain"
           };
           Bike bike2 = new Bike
           {
               Name = "Santa Cruz",
               type = "Mountain"
           };
           Bike bike3 = new Bike
           {
               Name = "Knolly",
               type = "Mountain"       
           };
           bikes.Add(bike1);
           bikes.Add(bike2);
           bikes.Add(bike3);
           test.Bikes = bikes;
           
           return View(test);
        }
