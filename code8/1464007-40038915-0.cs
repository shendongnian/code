    public ActionResult AufgabenDetails(int id)
    {
        var Aufgabe = new StageDBEntities().Aufgaben.Find(id);
        return View(Aufgabe);
    }
