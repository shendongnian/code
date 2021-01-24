    DateTime dt = DateTime.Now.ToLocalTime();
    string timeset = "08:56".Trim();
    DateTime oDate = DateTime.ParseExact(timeset, "HH:mm", null);
    System.Diagnostics.Debug.WriteLine(" System Time :  " + dt + " Set Time : " + oDate);
    var diffInSeconds = (dt - oDate).TotalSeconds;
    System.Diagnostics.Debug.WriteLine(diffInSeconds);
    if (Math.Abs(diffInSeconds) < 60)
    {
	    System.Diagnostics.Debug.WriteLine("Equal");
    }
