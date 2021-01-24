    Microsoft.Office.Interop.Outlook.Application outlookApplication = new Microsoft.Office.Interop.Outlook.Application(); ;
    Microsoft.Office.Interop.Outlook.AppointmentItem appointmentItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)outlookApplication.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
    // This line was added    
    appointmentItem.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
    appointmentItem.Subject = "Meeting Subject";
    appointmentItem.Body = "The body of the meeting";
    appointmentItem.Location = "Room #1";
    appointmentItem.Start = DateTime.Now;
    appointmentItem.Recipients.Add("test@test.com");
    appointmentItem.End = DateTime.Now.AddHours(1);
    appointmentItem.ReminderSet = true;
    appointmentItem.ReminderMinutesBeforeStart = 15;
    appointmentItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
    appointmentItem.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
    appointmentItem.Recipients.ResolveAll();
    appointmentItem.Display(true);
