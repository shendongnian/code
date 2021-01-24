    public async Task<bool> AddAppointment(ESF.Core.Models.ESFPortal_Events appointment)
    {
        Intent intent = new Intent(Intent.ActionInsert);
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, appointment.Title);
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, appointment.WhereWhen + " " + appointment.Description);
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(appointment.ExpireDate.Value));
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(appointment.ExpireDate.Value.AddHours(1)));
        intent.PutExtra(CalendarContract.ExtraEventBeginTime, GetDateTimeMS(appointment.ExpireDate.Value));
        intent.PutExtra(CalendarContract.ExtraEventEndTime , GetDateTimeMS(appointment.ExpireDate.Value.AddHours(1)));
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
        intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
        intent.SetData(CalendarContract.Events.ContentUri);
        ((Activity)Forms.Context).StartActivity(intent);
        return true;
    }
