        public string MakeRecurringEvent(AppointmentEvent message)
        {
        string startDay = "VALUE=DATE:" + GetFormatedDate(message.StartDate) + "T" + GetFormattedTime(message.StartTime);
        string endDay = "VALUE=DATE:" + GetFormatedDate(message.StartDate) + "T" + GetFormattedTime(message.EndTime);
        
        var organizer = "Listen To Customer Site Admin";
        var attendee = message.Attendee;
        string filePath = string.Empty;
        string path = HttpContext.Current.Server.MapPath(@"..\Content\Calendar\iCal\");
        filePath = path + message.Subject + ".ics";
        writer = new StreamWriter(filePath);
        
        writer.WriteLine("BEGIN:VCALENDAR");
        writer.WriteLine("VERSION:2.0");
        writer.WriteLine("METHOD:REQUEST");
        writer.WriteLine("PRODID:-//hacksw/handcal//NONSGML v1.0//EN");
        writer.WriteLine("BEGIN:VEVENT");     
        writer.WriteLine("ORGANIZER;CN=\"{0}\":MAILTO:{1}", organizer, message.Organizer);
        string[] arrAttendees = message.Attendee.Split(',');
        for (int countAtt = 0; countAtt < arrAttendees.Length - 1; countAtt++)
        {
            writer.WriteLine("ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=NEEDS-ACTION;RSVP=TRUE;CN=\"{0}\":MAILTO:{1}", attendee,
            arrAttendees[countAtt], arrAttendees[countAtt]);
        }        
        writer.WriteLine("DTSTART;" + startDay);
        writer.WriteLine("DTEND;" + endDay);
        if (message.IsRecurring)
        {
            switch (message.Frequency)
            {
                case "Daily":
                    writer.WriteLine("RRULE:FREQ=DAILY;UNTIL={0}", GetFormatedDate(message.EndDate));
                    break;
                case "Weekly":
                    writer.WriteLine("RRULE:FREQ=WEEKLY;UNTIL={0}", GetFormatedDate(message.EndDate));
                    break;
                case "Monthly1":
                    writer.WriteLine("RRULE:FREQ=MONTHLY;INTERVAL={0};UNTIL={1}",message.RecurranceMonth, GetFormatedDate(message.EndDate));
                    break;
                case "Monthly2":
                    writer.WriteLine("RRULE;TZID=America/New_York:FREQ=MONTHLY;UNTIL={0};BYDAY=\"{1}\"", GetFormatedDate(message.EndDate)+"T"+ GetFormattedTime(message.StartTime), "1FR");                   
                    break;
            }
        }
           
      
        writer.WriteLine("LOCATION:" + message.Location);
        writer.WriteLine("UID:{0}", Guid.NewGuid());
        writer.WriteLine("DESCRIPTION", message.From);
        writer.WriteLine("SUMMARY:" + message.Subject);      
        writer.WriteLine("ORANIZER:MAILTO:{0}", message.Organizer);        
        writer.WriteLine("X-ALT-DESC:FMTTYPE=text/html:{0}", message.Body);
        writer.WriteLine("END:VEVENT");
        writer.WriteLine("END:VCALENDAR");
        writer.Close();
        return filePath;
    }
