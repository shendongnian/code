    var time = DateTime.Now;
    Dictionary<DateTime, IEnumerable<int>> planning = new Dictionary<DateTime, IEnumerable<int>>();
    planning.Add(DateTime.UtcNow, new List<int>() { 0, 1, 2 });
    var root = new { today = time, planning = planning };
    var settings = new JsonSerializerSettings
    {
        DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
        DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'",
    };
    var json = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
    Console.WriteLine(json);
