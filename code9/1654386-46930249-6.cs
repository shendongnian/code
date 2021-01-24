    for(int i = 1; i < yourQuery.Count; i++){
        var differenceTicks = yourQuery[i].CurDateTime.Ticks - yourQuery[i-1].CurDateTime.Ticks;
        var differenceInMinutes = new TimeSpan(differenceTicks).TotalMinutes;
        // You can assign this value to any property within your list or 
        // to another list
    } 
