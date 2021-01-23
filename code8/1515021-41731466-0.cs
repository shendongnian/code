    List<string> paths = new List<string>();
    for (int i = 0; i < urls.Count(); i += 20)
    {
        string pathDateTime = urls[i].Substring(48, 12);
        string pathDateTimeLast = urls[i + 19].Substring(48, 12);
        var d = DateTime.ParseExact(pathDateTime, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
        var e = DateTime.ParseExact(pathDateTimeLast, "yyyyMMddHHmm", CultureInfo.InvariantCulture);
        paths.Add($"{countriesMainPath}[{d}---{e}]");
    }
