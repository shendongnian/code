    public ActionResult AufgabenDetails(int id)
    {
    
        StageDBEntities db = new StageDBEntitites();
        var Aufgabe = db.Aufgaben.Find(id)
        return View(Aufgabe);
    
    }
