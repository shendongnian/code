    // GET: Property ***TEST***
    public async Task<ActionResult> Index1(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Property property = await db.Property.FindAsync(id);
        if (property == null)
        {
            return HttpNotFound();
        }
    
        var viewModel = new PropertyIndexViewModel {
            Prop1 = property.Prop1
            // your stuff
        };
    
        return View(viewModel);
    }
