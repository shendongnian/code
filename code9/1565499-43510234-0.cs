    [HttpPost]
    public ActionResult Edit(MyModel M)
    {
        var db = new MyContextDB();
        if (ModelState.IsValid)
            {
            MyModel myModel = db.MyModel.Where(m => m.ID == M.ID).FirstOrDefault();
            if (myModel != null)
            {
                db.Entry(mymodel).CurrentValues.SetValues(M);
            
                try
                {                
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return View(e.InnerException);
                }
            }
        }
        return View(M);
    }
