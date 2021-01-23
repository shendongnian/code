     public ActionResult Create(CountryViewModel country)
     {
        var CC = new CustomerClient();
        var result = CC.findAll(); // assuming this return a collection of Customer
        var matches = result.Where(x=>country.CountryIds.Contains(x.Country);
        // to do : return something
     } 
