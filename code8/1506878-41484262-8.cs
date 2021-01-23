    public ActionResult<Thing> Get(int id) {
        Thing thing = GetThingFromDB();
    
        if (thing == null)
            return NotFound();
    
        return thing;
    }
