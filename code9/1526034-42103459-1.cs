    public int GetAgeGroup(DateTime birthYear)
    {
        int years = DateTime.Now.Years - birthYear.Years;
    
        if (birthYear > DateTime.Now.AddYears(-years))
            years--;
    
        if(years<=25)
            return 1;
        else if( years> 25 && years<=35)
            return 2;
        else if(... other checks)
        {
        
        }
        else
        {
            return 5
        }
    }
