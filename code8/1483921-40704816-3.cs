    private IQueryable<Flight> FlightsForPerson(Person person, int[] usedStaff, string position)
    {
        return flightStaffRepository
            .GetMany()
            .Include(elem => elem.Flight)
            .Where(elem => IsDateSuitable(elem.Flight.FlightDate.Value));
    }
    private Task<bool> IsGoodPersonForScheduleAsync(Person person, int[] usedStaff, string position)
    => FlightsForPerson(person, usedStaff, position).AnyAsync();
    private bool IsGoodPersonForSchedule(Person person, int[] usedStaff, string position)
    => FlightsForPerson(person, usedStaff, position).Any();
