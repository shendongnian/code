    public ActionResult Create([Bind(Include = "ID,LastName,Fund,PurchaseDate,Shares,PurchasePrice,PurchaseAmount")] Investments investments)
    {
        if (ModelState.IsValid)
        {
            
            var clientId = (from c in context.Clients
                 where c.LastName == investments.LastName
                 select new
                 {
                     c.ID
                 }).ToList().First();
            foreach(var investment in investements){
                 investment.Client_ID = clientId;
            }
            db.Ports.Add(investments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(investments);
    }
