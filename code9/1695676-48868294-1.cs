    var appointmentsofJohnInStBarth = dbContext.Appointments
        .Where(appointment => Appointment.Volunteer.Name = "John"
              && appointment.Church.Name = "Saint Bartholomew")
        .Select(appointment => new
        {
            StartTime = appointment.StartTime,
            EndTime = appointment.EndTime,
            Description = appointment.Description,
            Attendants = appointment.Volunteers
                .Select(volunteer => new
                {
                    Name = volunteer.Name,
                    Function = volunteer.Function,
                    Email = volunteer.Email,
                    ...
                 })
                 .ToList(),
        });
