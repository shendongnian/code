       [HttpPost]
       public ActionResult Create(CheckingAccount model){
            model.AccountNumber = (12 + db.checkAccounts.Count()).ToString().PadLeft(10, '0');
            db.checkAccounts.Add(checking);
            db.SaveChanges();
        }
