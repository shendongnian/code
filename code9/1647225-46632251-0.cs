     [HttpGet]
            public ActionResult Index()
            {
                Person p1 = new Person();
                p1.name = "Ian";
    
                List<Sport> sports = new List<Sport>();
                Sport s1 = new Sport();
                s1.description = "Football";
                sports.Add(s1);
                Sport s2 = new Sport();
                //s1.description = "Netball";   I'm guessing this is a typo?
                s2.description = "Netball";
                sports.Add(s2);
                p1.sports = sports;
    
                return View("Person", p1);
            }
    
            [HttpPost]
            public ActionResult Index(Person p1)
            {
                return View();
            }
