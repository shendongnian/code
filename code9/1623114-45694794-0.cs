    var data = svcContext.CreateQuery("myentity");
    if (info.FromDate != null && info.ToDate != null)
    {
        var compareFromDate = info.FromDate.Value.Date;
        var compareToDate = info.ToDate.Value.Date.AddDays(1);
        data = data.Where(r => r.GetAttributeValue<DateTime>("rundate") >= compareFromDate && r.GetAttributeValue<DateTime>("rundate") < compareToDate);
    }
