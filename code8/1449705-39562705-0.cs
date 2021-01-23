    /// <summary>
    /// A method that allows you to get all tables reserved in a specific period. tables are only returned if they are reserverd.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public IEnumerable<Table> GetAllReservedTables(DateTime start, DateTime end)
    {
        return this.rc.tReservation
            // filter by date range
            .Where(x => x.DateReservation >= start && x.DateReservation <= end)
            // ensure table is returned
            .Select(x => x.table);
    }
