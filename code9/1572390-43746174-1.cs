    var obj = new[] {
        new {
            target = "1",
            datapoints = new [] {
                new [] {
                    67.0,
                    1491609600.0
                }
            }
        },
        new {
            target = "2",
            datapoints = new [] {
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
    var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
