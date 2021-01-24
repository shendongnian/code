    List<string> appointmentTitles = new List<string>();
    foreach (int patientId in id)
    {
        var patientAppointment = ctx.Appointments.Where(x => x.Patient_id == patientId);
        if (patientAppointment != null && patientAppointment.Any())
        {
        // note there can be multiple appointments
            foreach (var appointment from patientAppointment)
            {
                appointmentTitles.Add(appointment.Title)
            }
        }
    }
