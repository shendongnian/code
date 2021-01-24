    public static List<Appointment> getAppointments(DateTime apptDate)
    {
        return _sourceEntities.Appointments
            .Where(a => a.ApptDate == apptDate && a.ClientID == 6) // Remove if not needed
            .Select(r =>
                new Appointment
                {
                    ApptDate = new DateTime(r.ApptDate.Year, r.ApptDate.Month, r.ApptDate.Day,
                        r.ApptTime.Hour, r.ApptTime.Minute, r.ApptTime.Second)
                })
            .ToList();
    }
