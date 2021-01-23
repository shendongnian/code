    Dim tzi As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time")
    Dim dt1 As DateTime = DateTime.Parse("01/01/2015 8:00")
    Dim dt2 As DateTime = TimeZoneInfo.ConvertTimeFromUtc(dt1, tzi)
    Dim dt3 As DateTime = DateTime.Parse("06/06/2015 8:00")
    Dim dt4 As DateTime = TimeZoneInfo.ConvertTimeFromUtc(dt3, tzi)
    Assert.IsFalse(dt2.IsDaylightSavingTime)  //January is not saving daylight
    Assert.IsTrue(dt4.IsDaylightSavingTime)  //June is
    dt2.ToString()  //This returns "01/01/2015 08:00:00"
    dt4.ToString() //This returns "06/06/2015 09:00:00"
