    // Get current Appointment
    var currentAppointment = db.Appointments.Find(id);
    // Make a brand new Appointment
    var appointment = new Appointment();
    // Map one to the other
    db.Entry(currentAppointment).CurrentValues.SetValues(appointment);
    // Change the ID
    appointment.AppID = Guid.NewGuid();
    // Add to database
    db.Appointments.Add(appointment);
    // Whatever else happens
    // Save
    db.SaveChanges();
