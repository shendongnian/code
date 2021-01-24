    public static int HowManyBirthDaysInSameDayOfWeek(DateTime dateOfBirth)
    {
        int iteration = 1;
        int counter = 0;
        for (DateTime d = dateOfBirth.AddYears(1); d.Date <= DateTime.Today; d = dateOfBirth.AddYears(++iteration))
        {
            if (d.DayOfWeek == dateOfBirth.DayOfWeek)
            {
                counter++;
            }
        }
    
        return counter;
    }
