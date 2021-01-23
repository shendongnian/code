    var activity_count = (from activity in db.Sponsor_Activitys
                          where activity.SponsorLevelId == pledgelvl
                          from attendee in db.Attendees.DefaultIfEmpty()
                          where attendee.RegistrationId == registration
                          select new
                          {
                              Activityid = activity.ActivityId,
                              NumAttending = db.Sponsor_Attendances.Count(x => x.ActivityId == activity.ActivityId)
                          }).ToList();
