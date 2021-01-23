    public IEnumerable<Appointment> GetAppointments(IEnumerable<DateTime> datesWithEverything)
    {
        using (OneClickContext context = new OneClickContext())
        {
            var query = from e in context.AppointmentSet
                        where datesWithEverything.Contains(e.StartDate)
                        select e;
            query = query.Union(from e in context.AppointmentSet
                               group e by DbFunctions.TruncateTime(e.StartDate) into grp
                               select grp.FirstOrDefault());
            return query.ToList();
        }
    }
