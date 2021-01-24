    var todayStatus =
        from s in actiContext.DeviceStatus
        .Include(s1 => s1.Device.Panel.Select(d => new 
                                                {
                                                  d.DeviceId,
                                                  d.DeviceName,
                                                  d.PanelID
                                                }))
        where DbFunctions.TruncateTime(s.TimeStamp) == DbFunctions.TruncateTime( DateTimeOffset.Now)
                && s.Device.Panel.Mac == mac
                && (s.Device.Ty == 4 || s.Device.Ty == 9)
        select s;
    var tempList = todayStatus.toList();
