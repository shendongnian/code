       var query = from activity in db.Sponsor_Activitys
                
                // Left outer join onto sponsor_attendances
                join attendance in db.Sponsor_Attendances
                on activity.ActivityId equals attendance.ActivityId into g
                from q in g.DefaultIfEmpty()
                
                join attendee in db.Attendees
                on q.AttendeeId equals attendee.AttendeeId
                
                where attendee.RegistrationId == registration && 
                      activity.SponsorLevelId == pledgelvl
                      
                select new
                {
                    Activityid = activity.ActivityId,
                    NumAttending = db.Sponsor_Attendances.Count(x => x.ActivityId == activity.ActivityId)
                }
