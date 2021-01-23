    public ActionResult Create()
        {
            ViewBag.RoundId = new SelectList(db.Round, "RoundID", "RoundID");
            ViewBag.AwayClubID = new SelectList(db.Clubs, "ClubID", "ClubID");
            ViewBag.HomeClubId = new SelectList(db.Clubs, "ClubID", "ClubID");
            return View();
        }
