    if (!String.IsNullOrWhiteSpace(AppConfigHelper.EndDate))
    {
        reportDate = DateTime.ParseExact(AppConfigHelper.EndDate, "ddMMyyyy", null);
        reportDate = reportDate.AddDays(1);
    }
