    model.TimeZoneId = selectedSite.TimeZoneId;
    model.AllTimeZones = tzHelper.GetTimeZoneList().Select(x =>
                       new SelectListItem
                       {
                           Text = x,
                           Value = x,
                           Selected = model.TimeZoneId == x
                       });
