    private async Task<bool> IsGoodPersonForSchedule(Person person, int[] usedStaff, string position)
    {
        //...
        var currPersonFlights = await flightStaffRepository
            .GetMany()
            .Include(elem => elem.Flight)
            .Where(elem => IsDateSuitable(elem.Flight.FlightDate.Value))
            .Include(elem => elem.Flight.Route)
            .ToListAsync();
        //...
        return true;
    }
