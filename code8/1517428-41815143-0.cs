      var dateTimeByStringLookup = new Dictionary<string, List<DateTime>>()
                    {
                        {"a", new List<DateTime>() {new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)}}
                    };
                    var datetimes = new List<DateTime>();
                    dateTimeByStringLookup.TryGetValue("a", out datetimes);
