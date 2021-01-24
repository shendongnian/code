    private Information GetFirstMatchingInformationByPeriod(
        List<Information> informations
        , DateTime dateToCheck)
    {
        var information = informations.FirstOrDefault(information 
                                                      => information.Periods                                                                         
                                                                    .Any(period
                                                        => period.dateToCheck >= period.StartDate 
                                                           && dateToCheck < period.EndDate);
        if(information == null) return null;
        var firstMatchingPeriod = information.Periods.First(period => dateToCheck >= period.StartDate 
                                                           && dateToCheck < period.EndDate);
         information.Periods = new List<Period>{ firstMatchingPeriod } ;
         return information;
    }
