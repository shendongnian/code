    var context = _programmeRepository.GetGenericRepository.GetDbContext as ConferenceDbContext;
    context.Entry(attendees).State = System.Data.Entity.EntityState.Detached;
    context.ProgrammeObjects.Attach(programme);
    var attendee = programme.presenters
                .Where(c => c.AttendeesId ==    attendees.AttendeesId).SingleOrDefault();
    programme.presenters.Remove(attendee);
            
    context.Entry(programme).State = System.Data.Entity.EntityState.Modified;
            
    context.SaveChanges();
