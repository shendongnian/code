    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Property1, Property2, Property3, EmailAddress")] Object myObject)
    {
        if(ModelState.IsValid)
        {
            if(db.TableName.Any(x => x.Email.Equals(myObject.EmailAddress, StringComparison.CurrentCultureIgnoreCase)
            {
                ModelState.AddModelError("EmailAddress", "This Email Already Exists!");
                return View(myObject);
            }
    
            /* otherwise continue */
        }
    }
