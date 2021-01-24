    //some variables for demo purposes
    DateTime DateStart = DateTime.Now;
    DateTime DateEnd = DateStart.AddMinutes(105);
    string Summary = "Small summary text";
    string Location = "Event location";
    string Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.";
    string FileName = "CalendarItem";
    
    //create a new stringbuilder instance
    StringBuilder sb = new StringBuilder();
    
    //start the calendar item
    sb.AppendLine("BEGIN:VCALENDAR");
    sb.AppendLine("VERSION:2.0");
    sb.AppendLine("PRODID:stackoverflow.com");
    sb.AppendLine("CALSCALE:GREGORIAN");
    sb.AppendLine("METHOD:PUBLISH");
    
    //create a time zone if needed, TZID to be used in the event itself
    sb.AppendLine("BEGIN:VTIMEZONE");
    sb.AppendLine("TZID:Europe/Amsterdam");
    sb.AppendLine("BEGIN:STANDARD");
    sb.AppendLine("TZOFFSETTO:+0100");
    sb.AppendLine("TZOFFSETFROM:+0100");
    sb.AppendLine("END:STANDARD");
    sb.AppendLine("END:VTIMEZONE");
    
    //add the event
    sb.AppendLine("BEGIN:VEVENT");
    
    //with time zone specified
    sb.AppendLine("DTSTART;TZID=Europe/Amsterdam:" + DateStart.ToString("yyyyMMddTHHmm00"));
    sb.AppendLine("DTEND;TZID=Europe/Amsterdam:" + DateEnd.ToString("yyyyMMddTHHmm00"));
    //or without
    sb.AppendLine("DTSTART:" + DateStart.ToString("yyyyMMddTHHmm00"));
    sb.AppendLine("DTEND:" + DateEnd.ToString("yyyyMMddTHHmm00"));
    
    sb.AppendLine("SUMMARY:" + Summary + "");
    sb.AppendLine("LOCATION:" + Location + "");
    sb.AppendLine("DESCRIPTION:" + Description + "");
    sb.AppendLine("PRIORITY:3");
    sb.AppendLine("END:VEVENT");
    
    //end calendar item
    sb.AppendLine("END:VCALENDAR");
    
    //create a string from the stringbuilder
    string CalendarItem = sb.ToString();
    
    //send the calendar item to the browser
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    Response.ContentType = "text/calendar";
    Response.AddHeader("content-length", CalendarItem.Length.ToString());
    Response.AddHeader("content-disposition", "attachment; filename=\"" + FileName + ".ics\"");
    Response.Write(CalendarItem);
    Response.Flush();
    HttpContext.Current.ApplicationInstance.CompleteRequest();
