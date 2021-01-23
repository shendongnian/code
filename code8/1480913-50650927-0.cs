    #region Googlestuff
    var service = new CalendarService(new Google.Apis.Services.BaseClientService.Initializer()
    {
        ApiKey = "xxxx",
        ApplicationName = "xxxx",
    });
    EventsResource.ListRequest lr = service.Events.List(calendarID);
    #endregion
    List<DateTime> starts = new List<DateTime>();    
    foreach (var myEvent in lr.Execute().Items)
    {
        string start = myEvent.Start.DateTime.ToString(); //it gives something like "11.09.2017 09:30:00"
        starts.Add(new DateTime(
        Convert.ToUInt16(start.Split(' ')[0].Split('.')[2]), //takes year
        Convert.ToUInt16(start.Split(' ')[0].Split('.')[1]), //takes month
        Convert.ToUInt16(start.Split(' ')[0].Split('.')[0]), //takes day
        Convert.ToUInt16(start.Split(' ')[1].Split(':')[0]), //takes hour
        Convert.ToUInt16(start.Split(' ')[1].Split(':')[1]), //takes minute
        Convert.ToUInt16(start.Split(' ')[1].Split(':')[2]))); //takes second
    }
    Console.WriteLine(starts);
