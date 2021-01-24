    var obj = new List<dynamic> {
        new {
            target = "1",
            datapoints = new List<dynamic> {
                new [] {
                    67.0,
                    1491609600.0
                }
            }
        },
        new {
            target = "2",
            datapoints = new List<dynamic> {
                new [] {
                    54.0,
                    1491091200.0
                },
                new [] {
                    65.0,
                    1491177600.0
                },
            }
        }
    };
    var target2 = obj.Where(t => t.target == "2").Single();
    target2.datapoints.Add(new [] {
        64.0,
        1492214400.0
    });
    target2.datapoints.Add(new[] {
        57.0,
        1492732800.0
    });
    var target3 = new {
        target = "3",
        datapoints = new List<dynamic> { }
    };
    target3.datapoints.Add(new[] {
        72.0,
        1492819200.0
    });
    obj.Add(target3);
    var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
