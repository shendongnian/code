    var durs = new List<TimeSpan>();
    durs.Add(Dt11.TimeOfDay.Subtract(Dt1.TimeOfDay));
    durs.Add(Dt12.TimeOfDay.Subtract(Dt2.TimeOfDay));
    .
    .
    .
    
    durs.Add(Dt20.TimeOfDay.Subtract(Dt10.TimeOfDay));
