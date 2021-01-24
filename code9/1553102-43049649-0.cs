    public ActionResult QuestionBlock(int id) {
        ApplicationDbContext db = new ApplicationDbContext();
        var questionblocks = db.QuestionBlocks.Take(id);
        return PartialView("Name_Of_PartialView",questionblocks);
    }
 
