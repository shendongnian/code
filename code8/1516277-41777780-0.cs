    //create appointment
    var appointment = new Windows.ApplicationModel.Appointments.Appointment();
    // ... set its properties
    appointment.StartTime = DateTime.Now + TimeSpan.FromDays(1);
    appointment.Subject = "Meeting subject";
    appointment.Details = "Meeting description";
    
    //show popup to add to calendar
    string appointmentId = 
       await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(
                             appointment, 
                             rect, 
                             Windows.UI.Popups.Placement.Default );
