    if (!reader.IsDBNull(6)) {
      var temporaryDate = reader.GetValue(6).ToString();
      DateTime outDate;
      if (DateTime.TryParseExact(temporaryDate, "M/dd/yyyy h:mm:ss tt", null, DateTimeStyles.None, out outDate))
      {
        temp.StartDate = outDate;
      }
    }
