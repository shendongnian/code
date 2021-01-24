    private Information GetFirstMatchingInformationByPeriod(
        List<Information> informations
        , DateTime dateToCheck)
    {
        // Find the first information that match your search criteria
        var information = informations.FirstOrDefault(information 
                                                      => information.Periods                                                                         
                                                                    .Any(period
                                                        => period.dateToCheck >= period.StartDate 
                                                        && period.dateToCheck < period.EndDate);
        // If not any found, return null.
        if(information == null) return null;
        var firstMatchingPeriod = information.Periods
                                             .First(period => dateToCheck >= period.StartDate 
                                                           && dateToCheck < period.EndDate);
         // Information found. 
         // Change it's periods with a List containin only the first matching period. 
         information.Periods = new List<Period>{ firstMatchingPeriod } ;
         return information;
    }
