    protected EKEventStore eventStore;
    public AppointmentServiceh_iOS()
    {
        eventStore = new EKEventStore();
    }
    public async Task<bool> AddAppointment(ESF.Core.Models.ESFPortal_Events appointment)
    {
        var granted = await eventStore.RequestAccessAsync(EKEntityType.Event);//, (bool granted, NSError e) =>
        if (granted.Item1)
        {
            EKEvent newEvent = EKEvent.FromStore(eventStore);
            newEvent.StartDate = DateTimeToNSDate(appointment.ExpireDate.Value);
            newEvent.EndDate = DateTimeToNSDate(appointment.ExpireDate.Value.AddHours(1));
            newEvent.Title = appointment.Title;
            newEvent.Notes = appointment.WhereWhen;
            newEvent.Calendar = eventStore.DefaultCalendarForNewEvents;
            NSError e;
            eventStore.SaveEvent(newEvent, EKSpan.ThisEvent, out e);
            return true;
        }
        else
        {
            new UIAlertView("Access Denied", "User Denied Access to Calendar Data", null, "ok", null).Show();
            return false;
        }
    }
    public DateTime NSDateToDateTime(NSDate date)
    {
        double secs = date.SecondsSinceReferenceDate;
            if (secs < -63113904000)
                return DateTime.MinValue;
            if (secs > 252423993599)
                return DateTime.MaxValue;
            return (DateTime)date;
        }
    
        public NSDate DateTimeToNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Local);
            return (NSDate)date;
        }
