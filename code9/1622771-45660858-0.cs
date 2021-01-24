    public ActionResult userdetails()
    { 
        List<AllServices> lservices = new List<AllServices>();
        AllServices services = new AllServices();
        services.Appointments = dbcontext.Appointments.ToList();
        services.Consultations = dbcontext.Consultations.ToList();
        services.Contacts = dbcontext.Contacts.ToList();
        lservices.Add(services);
        return View(lservices);
    }
