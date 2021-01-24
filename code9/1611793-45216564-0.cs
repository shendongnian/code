    public static int HowManyBirthDaysInSameDayOfWeek(DateTime dateOfBirth)
    {
        int counter = 0;
        for (DateTime d = dateOfBirth.AddYears(1); d.Date <= DateTime.Today; d = d.AddYears(1))
        { 
             if (d.DayOfWeek == dateOfBirth.DayOfWeek)
             {
                 counter++;
             }
         }    
         return counter;
     }
    
