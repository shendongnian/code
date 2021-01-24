    private List<Information> FilterInformationsPeriods(
        List<Information> informations
        , DateTime dateToCheck)
    {
        foreach(var information in informations)
        {
            information.Periods = information.Periods
                                             .Where(period => dateToCheck >= period.StartDate 
                                                           && dateToCheck < period.EndDate)
                                             .ToList();
        }
        
        return informations;
    }
