    var min = DateTime.Parse("1988/02/10");
    var max = DateTime.Parse("2016/01/05");
    var minTicks = min.Ticks;
    var maxTicks = max.Ticks;
    
    var baseTicks = maxTicks-minTicks;
    
    var rnd = new Random();
    
    var toAdd = (long)(rnd.NextDouble()*baseTicks);
    
    var newDate = new DateTime(minTicks+toAdd);
