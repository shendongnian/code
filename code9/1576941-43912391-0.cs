    public ActionResult Details([Bind(Prefix = "id")]int participantId = 0)
    {
        // Check participant exists
        Participant participant = _db.Participants.Find(participantId);
        if (participant == null)
        {
            return HttpNotFound();
        }
        var model = (from p in _db.Participants
                        join g in _db.Genders on p.Gender equals g.Id
                        where p.Id == participantId
                        select new ParticipantDetailsViewModel
                        {
                            Id = p.Id,
                            SiteId = p.SiteId,
                            Status = p.Status,
                            Gender = g.Name,
                            Title = p.Title,
                            Name = p.Name,
                            City = p.City,
                            Postcode = p.Postcode,
                            Telephone = p.Telephone,
                            Notes = p.Notes
                        }).FirstOrDefault();
        return View(model);
    }
