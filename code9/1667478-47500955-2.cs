    public ActionResult Details(int? id)
    {
        if (id == null)
        {
           return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }    
         var item = (from ap in db.ProcessArea
                        join mg in db.GenericGoal on ap.IdProcessArea equals mg.IdGenericGoal
                        where ap .Id == id.Value
                        select new AreaProcessoModelView()
                        {
                            InitialsLevelMaturity = mg.Initials,
                            NameLevelMaturity = mg.Name,
                            DescriptionLevelMaturity = mg.Description,
                            Initials = ap.Initials,
                            Name = ap.Name,
                            Description = ap.Description
                        }).FirstOrDefault();
          
       if(item ==null)
       {
            return HttpNotFound();  // Or a return a view with message "item not found"
       }
       return View(item);
    }
