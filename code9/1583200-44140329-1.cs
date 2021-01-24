    if(inputDate != null)
    {
        /* Assuming inputDate.Value only contains the Date part.
           i.e. : 2017-05-23 instead of 2017-05-23 10:00:32 */
        DateTime inputDateFirstSecond = inputDate.Value;
        DateTime inputDateLastSecond = inputDateFirstSecond
            .AddHours(23)
            .AddMinutes(59)
            .AddSeconds(59);
        dataContext.myTable.Where(r => r.myDate.HasValue &&
            (r.myDate.Value >= inputDateFirstSecond && r.myDate.Value <= inputDateLastSecond)
        )
    }    
