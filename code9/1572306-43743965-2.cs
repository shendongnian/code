    var nightTime = new DateTimeInterval()
    {
    	From = new DateTime(0001, 01, 01, 20, 00, 00),
    	To = new DateTime(0001, 01, 02, 6, 00, 00)
    };
    var shiftTime = new DateTimeInterval()
    {
    	From = new DateTime(0001, 01, 01, 21, 00, 00),
    	To = new DateTime(0001, 01, 01, 8, 00, 00)
    };
    
    if(shiftTime.From.Value.Hour > shiftTime.To.Value.Hour)
    {
    	shiftTime.To = shiftTime.To.Value.AddDays(1);
    }
    			
    var overlap = DateTimeUtils.GetIntervalIntersection(nightTime, shiftTime);
    var duration = (overlap.To.Value - overlap.From.Value).TotalHours;
