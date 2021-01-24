    if (LI[Constants.FieldName_ReqLst_DueDate] != null)
    {
      // create a time zone object hard coding to local time zone
      var timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      var tempDate = (DateTime)LI[Constants.FieldName_ReqLst_DueDate];
      req.DueDate = TimeZoneInfo.ConvertTimeFromUtc(tempDate, timeInfo);
    }
