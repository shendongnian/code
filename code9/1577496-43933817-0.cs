    public ActionResult Edit(ParticipantDetailsViewModel viewModel)
    {
          if (ModelState.IsValid)
          {
               var participant = _db.Participants.FirstOrDefault(p => p.Id == viewModel.Id);
               //set all properties whith new values
               participant.SiteId = viewModel.SiteId
               
               _db.Entry(participant).State = EntityState.Modified;
               _db.SaveChanges();
               return RedirectToAction("Index", new { id = viewModel.Id });
          }
          return View(viewModel);
    }
