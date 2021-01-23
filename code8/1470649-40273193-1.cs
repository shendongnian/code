    public static DateTime SetKind(this DateTime DT, DateTimeKind DTKind)
    {        
        var NewDT = New DateTime(DT.Year, DT.Month, DT.Day, DT.Hour, DT.Minute, DT.Second, DT.Millisecond, DTKind);
        Return NewDT;
    }
