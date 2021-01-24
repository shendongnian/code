    List<DateRange> dates = new List<DateRange>();
    dates.Add(new DateRange()
    {
        StartDate = new DateTime(2017, 07, 10),
        EndDate = new DateTime(2017, 07, 18)
    });
    
    dates.Add(new DateRange()
    {
        StartDate = new DateTime(2017, 07, 28),
        EndDate = new DateTime(2017, 07, 28)
    });
    
    DateRange search1 = new DateRange()
    {
        StartDate = new DateTime(2017, 07, 11),
        EndDate = new DateTime(2017, 07, 12)
    };
    
    DateRange search2 = new DateRange()
    {
        StartDate = new DateTime(2017, 07, 28),
        EndDate = new DateTime(2017, 07, 29)
    };
    
    var result1 =  dates.Where(x => search1.StartDate >= x.StartDate && search1.StartDate <= x.EndDate || 
                    search1.EndDate <= x.StartDate && search1.EndDate >= x.EndDate);
    
    var result2 = dates.Where(x => search2.StartDate >= x.StartDate && search2.StartDate <= x.EndDate ||
                    search2.EndDate <= x.StartDate && search2.EndDate >= x.EndDate);
