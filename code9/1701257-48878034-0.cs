        PartyId = new EntityReference(SystemUser.EntityLogicalName, userResponse.UserId)
    };
    
    // Create the appointment instance.
    Appointment appointment = new Appointment
    {
        Subject = "Test Appointment",
        Description = "Test Appointment created using the BookRequest Message.",
        ScheduledStart = DateTime.Now.AddHours(1),
        ScheduledEnd = DateTime.Now.AddHours(2),
        Location = "Office",
        RequiredAttendees = new ActivityParty[] { party },
        Organizer = new ActivityParty[] { party }                        
    };                    
    
    // Use the Book request message.
    BookRequest book = new BookRequest
    {
        Target = appointment
    };
