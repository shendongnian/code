    if(appointment.IsMeeting)
    {
      List<Attendee> remove = new List<Attendee>();
     foreach (var attendee in appointment.RequiredAttendees)
     {
        if (IsResource(attendee.Address) && attendee.Address != resourceId)
        {
            remove.Add(attendee);
        }
     }
     remove.ForEach(a => appointment.RequiredAttendees.Remove(a));
     if (!appointment.RequiredAttendees.Any(a => a.Address == resourceId))
     {
        appointment.RequiredAttendees.Add(resourceId);
     }
    }
