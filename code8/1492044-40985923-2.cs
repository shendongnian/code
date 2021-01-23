    public static string FormatOpenCloseFromGoogle(GooglePlaceApiOpeningHours openingHoursModel)
    {
        if (openingHoursModel == null || openingHoursModel.periods == null) return null;
        // build a list of open days from Google data
        var list = openingHoursModel.periods
            .GroupBy(p => p.open.day)
            .Select(g => new OpenCloseDaysModel
            {
                day = g.Key,
                is_open = true,
                range = g.Select(p => new OpenCloseResultModel
                        {
                            start = p.open.time.Substring(0, 2) + ":" + p.open.time.Substring(2, 2),
                            end = p.close != null ? p.close.time.Substring(0, 2) + ":" + p.close.time.Substring(2, 2) : "23:59"
                        })
                        .OrderBy(r => r.start)
                        .ToList()
            })
            .ToList();
        // fill in missing days
        for (int i = 0; i < 7; i++)
        {
            if (!list.Any(m => m.day == i))
                list.Add(new OpenCloseDaysModel { day = i, is_open = false, range = null });
        }
        // sort days with Sunday at the end and return the serialized result
        var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        return JsonConvert.SerializeObject(list.OrderBy(m => m.day > 0 ? m.day : 7), settings);   
    }
