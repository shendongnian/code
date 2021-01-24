    public ActionResult GetClients()
    {
      MyDBEntities myDBEntites = new MyDBEntities();
      var clients = from c in myDBEntites.Client
                    where c.name.EndsWith("r")
                select c;
    
     return View(clients);
    }
