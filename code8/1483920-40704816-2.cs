    private bool IsGoodPersonForSchedule(Person person, int[] usedStaff, string position)
    {
        return flightStaffRepository
            .GetMany()
            .Include(elem => elem.Flight)
            .Where(elem => IsDateSuitable(elem.Flight.FlightDate.Value))
            .Any();
    }
