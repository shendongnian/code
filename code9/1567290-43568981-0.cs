    private List<Information> FilterInformationsPeriods(
        List<Information> informations
        , DateTime dateToCheck)
    {
        foreach(var information in informations)
        {
            information.Periods = information.Periods
                                             .Where(y => dateToCheck >= y.StartDate 
                                                      && dateToCheck < y.EndDate)
                                             .ToList();
        }
        
        return informations;
    }
