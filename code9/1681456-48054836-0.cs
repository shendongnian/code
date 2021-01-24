    public void AddToAppointment(Appointment newAppointment, string connectionString)
    {
            using (var myContext = new SMBASchedulerEntities(connectionString))
            {
                myContext.Appointments.Add(newAppointment);
                myContext.SaveChanges();
            }
    }
