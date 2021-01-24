    var dow = DateTime.Now.DayOfWeek;
    if(dow != DayOfWeek.Sunday || dow != DayOfWeek.Saturday)
    {
        Timer_bolovanje(new TimeSpan(20, 00, 00));
        Timer_godisnji(new TimeSpan(20, 05, 00));
    }
