    var applicant = db.Applicants
      .Include(a=>a.Notification)
      .FirstOrDefault(a=>a.ApplicantId = model.ApplicantId);
    
    if (applicant == null)
      // Handle missing Applicant scenario here.
    
    SetApplicant(model, applicant);
    SetNotification(model, applicant.Notification);
    
    db.SaveChanges();
