    public void InsertAttendee(List<FinalizedWebinar> webinars)
    {
        using (webinarFinalizedAttendeesListDbContext context = new webinarFinalizedAttendeesListDbContext(connectionString))
        {
            foreach(var webinar in webinars) {
                context.WebinarFinalAttendee.Add(webinar);
            }
    
            context.SaveChanges();
        }
    }
