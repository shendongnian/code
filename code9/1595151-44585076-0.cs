    context.Programmes.Attach(programme);
     var entry = context.Entry(programme);
     entry.State = EntityState.Modified;
     var attendee = programme.presenters
                .Where(c => c.AttendeesId == attendees.AttendeesId).SingleOrDefault();
    
            programme.presenters.Remove(attendee);
     context.SaveChanges();
