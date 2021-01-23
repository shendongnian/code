    public IEnumerable<DateTime> GetDatesWithAppointments()
    {
        using (OneClickContext context = new OneClickContext())
        {
            var query = (from e in context.AppointmentSet
                        order by e.StartDate
                        select e.StartDate).Distinct();
            return query;
        }
    }
