    var sb = new StringBuilder();
    var s = "s";
    var time = new TimeSpan(0, 0, timer);
    var continuation = false;
    if (time.Days > 0)
    {
    	sb.Append($"{time.Days} day{(time.Days != 1 ? s : String.Empty)}, ");
    	continuation = true;
    }
    if (time.Hours > 0 || continuation)
    {
    	sb.Append($"{time.Hours} hour{(time.Hours != 1 ? s : String.Empty)}, ");
    	continuation = true;
    }
    if (time.Minutes > 0 || continuation)
    {
    	sb.Append($"{time.Minutes} minute{(time.Minutes != 1 ? s : String.Empty)}, ");
    	continuation = true;
    if (continuation) sb.Append("and ");
    sb.Append($"{time.Seconds} second{(time.Seconds != 1 ? s : String.Empty)}");
    return sb.ToString();
