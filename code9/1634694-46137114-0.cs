    public ActionResult CoverLetterCenter()
    {
        var candidateId = User.Identity.GetUserId();
        var coverLetterList = _context.CoverLetters
            // .Include("Company")
            .Where(r => r.CandidateId == candidateId).OrderByDescending(r => r.datetime).AsEnumerable(); // or .ToList()
    
        return View(coverLetterList);
    }
