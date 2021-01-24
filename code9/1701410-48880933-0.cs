    var confRead = new System.Configuration.AppSettingsReader();
    var fromDay= (int)confRead.GetValue("FromDay", typeof(int));            
    var toDay = (int)confRead.GetValue("ToDay", typeof(int));
    var result = IsValidDay(DateTime.Now, fromDay, toDay);
    private bool IsValidDay(DateTime day, int fromDay = 1, int toDay = 5)
    {
        var testDay = (int)day.DayOfWeek;
        return (fromDay > testDay && testDay > toDay);
    }
