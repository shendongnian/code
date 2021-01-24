    var datetimeNow = DateTime.Now; // Wednesday
    var selectedDay = Datetime.Now.AddDays(-1); //Tuesday
    if(datetimeNow.DayOfWeek < selectedDay.DayOfWeek)
        selectedDay = selectedDay.AddDays(7); // Will then be the coming tuesday
    
