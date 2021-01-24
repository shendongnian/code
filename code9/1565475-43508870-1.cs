    public static int GetMinutes(DateTime dateTime) {
        return (dateTime.Hour * 60) + dateTime.Minutes
    }
    public bool IsBetween(DateTime target, DateTime start, DateTime end) {
        var targetMinutes = GetMinutes(target);
        var startMinutes = GetMinutes(start);
        var endMinutes = GetMinutes(end);
        
        return startMinutes <= targetMinutes && endMinutes >= targetMinutes ;
    }
