    public async Task AddAppointment(ESF.Core.Models.ESFPortal_Events appointment)
    {
        var appointmentRcd = new Windows.ApplicationModel.Appointments.Appointment();
        var date = appointment.ExpireDate.Value.Date;
        var time = appointment.ExpireDate.Value.TimeOfDay;
        var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
        var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0, timeZoneOffset);
        appointmentRcd.StartTime = startTime;
    
        // Subject
        appointmentRcd.Subject = appointment.Title;
        // Location
        appointmentRcd.Location = appointment.WhereWhen;
        // Details
        appointmentRcd.Details = appointment.Description;
        // Duration          
        appointmentRcd.Duration = TimeSpan.FromHours(1);
        // All Day
        appointmentRcd.AllDay = false;
        //Busy Status
        appointmentRcd.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.Busy;
        // Sensitivity
        appointmentRcd.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Public;
        Rect rect = new Rect(new Point(10, 10), new Size(100, 200));
    string retVal = await AppointmentManager.ShowAddAppointmentAsync(appointmentRcd, rect, Windows.UI.Popups.Placement.Default);
        return !string.IsNullOrEmpty(retVal);
    }
