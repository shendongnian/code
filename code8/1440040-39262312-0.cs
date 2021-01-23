        //Connect to exchange
        var ewsProxy = new ExchangeService(ExchangeVersion.Exchange2013);
        ewsProxy.Url = new Uri("https://outlook.office365.com/ews/exchange.asmx");
        //Create the meeting
        var meeting = new Appointment(ewsProxy);
        ewsProxy.Credentials = new NetworkCredential(_Username, _Password);
        meeting.RequiredAttendees.Add(_Recipient);
        // Set the properties on the meeting object to create the meeting.
        meeting.Subject = "Meeting";
        meeting.Body = "Please go to the meeting.";
        meeting.Start = DateTime.Now.AddHours(1);
        meeting.End = DateTime.Now.AddHours(2);
        meeting.Location = "Location";
        meeting.ReminderMinutesBeforeStart = 60;
        // Save the meeting to the Calendar folder and send the meeting request.
        meeting.Save(SendInvitationsMode.SendToAllAndSaveCopy); 
