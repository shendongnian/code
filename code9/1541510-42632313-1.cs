    var sb = new StringBuilder();
    var s = "s";
    var time = new TimeSpan(0, 0, timer);
    var continuationCount = 0;
    if (time.Days > 0)
    {
    	sb.Append($"{time.Days} day{(time.Days != 1 ? s : String.Empty)}, ");
    	continuationCount++;
    }
    if (time.Hours > 0 || continuationCount > 0)
    {
    	sb.Append($"{time.Hours} hour{(time.Hours != 1 ? s : String.Empty)}, ");
    	continuationCount++;
    }
    if (time.Minutes > 0 || continuationCount > 0)
    {
    	sb.Append($"{time.Minutes} minute{(time.Minutes != 1 ? s : String.Empty)}{continuationCount > 0 ? "," : String.Empty} ");
    	continuationCount++;
    if (continuationCount > 0) sb.Append("and ");
    sb.Append($"{time.Seconds} second{(time.Seconds != 1 ? s : String.Empty)}");
    return sb.ToString();
