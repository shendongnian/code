    public TimeSpan? FirstStartDifference 
    {
        get 
        {
            if (!CurDateTime.HasValue)
            {
                return null
            }
    
            return (CurDateTime - DateTime.Today).Duration(); 
        } 
    }
