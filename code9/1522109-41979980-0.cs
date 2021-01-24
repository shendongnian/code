    TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
    foreach (DataRow row in dataTable.Rows)
    {
        DateTime cstDateTime = row.Field<DateTime>("CSTDatetime");
        DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(cstDateTime, cstZone);
        row.SetField("CSTDatetime", utcDateTime);
    }
