    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(votingModel chk) {
        // chk.ElectionId can never be null because this property is not nullable in VotingModel 
        long id = chk.ElectionId; 
        // assuming there is only a single entry with this ElectionId in the DB
        votingModel existing = db.votingModels.SingleOrDefault(v => v.ElectionId == id); 
        
        // SingleOrDefault returns null if no entry matches the condition
        if (existing == null) {
            return View("NotFound");
        }
           
        return View(existing);
    }
