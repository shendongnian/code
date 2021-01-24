    DateTime inputTime = DateTime.Now; // initializing with current DateTime
    bool isGreater = inputTime.TimeOfDay > new TimeSpan(8,15,0);
    if(isGreater)
    {
        // code here time is Greater
    }
