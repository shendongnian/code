    public List<Appointment> getAppointments (DateTime AppointmentDate)
     {
        List<Appointment> query = _sourceEntities.Appointments.Where(a => a.ApptDate == AppointmentDate && a.ClientID==6).ToList();
        return _sourceEntities.Appointments.Select(r => new Appointment
    
        {
                newAppointment.ApptDate = ew DateTime(r.ApptDate.Year, r.ApptDate.Month, r.ApptDate.Day, r.ApptTime.Hour, r.ApptTime.Minute, r.ApptTime.Second);
                //map other variables here
        });
    
    }
