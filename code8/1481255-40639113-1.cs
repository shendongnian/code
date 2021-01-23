    public ActionResult MojeKonto()
    {
        // Initialise a blank variable for if they're not logged in, or are an invalid user
        Konto konto = null;
        // Only try to load if they're logged in
        if (User.Identity.IsAuthenticated) {
            // Instantiate the DbContext to connect to database
            using(var db = new AplikacjaContext()) {
                // Attempt to load from database using Username, note that 'OrDefault' means if it doesn't exist, "konto" variable will stay null
                konto = db.MojeKonto.SingleOrDefault(m => m.pesel == User.Identity.Name);
            }
        }
        if (konto == null) {
            // You could do something here if you can't load more detail about the user if you wanted
        }
        return View(konto);
    }
