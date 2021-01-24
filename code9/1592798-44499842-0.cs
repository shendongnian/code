    public ActionResult Index(string subjectId) /
     {
      var participants = db.Participant.Where(x =>
                         x.SubjectsID.ToString() == subjectId).ToList();
      return View(participants);
     }
