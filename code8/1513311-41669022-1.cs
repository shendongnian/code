        // POST: Matches/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "MatchId,HomeClubId,AwayClubID,Club1Goals,Club2Goals,RoundId")] Match match)
    {
        if (ModelState.IsValid)
        {
            db.Match.Add(match);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.RoundId = new SelectList(db.Round, "RoundID", "RoundID", match.RoundId);
        ViewBag.AwayClubID = new SelectList(db.Clubs, "ClubID", "ClubID", match.AwayCludId);
        ViewBag.HomeClubId = new SelectList(db.Clubs, "ClubID", "ClubID", match.HomeClubId);
        return View(match);
    }
