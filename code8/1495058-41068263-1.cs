    [HttpPost]
    public ActionResult Create(CheckingAccount model){
        //fancy black magic binds all of the form properties 
        //to this model parameter for you!
        model.AccountNumber = (12 + db.checkAccounts.Count()).ToString().PadLeft(10, '0');
        db.checkAccounts.Add(model);
        db.SaveChanges();
    }
