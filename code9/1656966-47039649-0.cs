            var rawData = System.IO.File.ReadAllText("aa.txt");
            var data = rawData.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Select(k =>
                new
                {
                    Type = k.Split(';')[0],
                    Size = k.Split(';')[1],
                    Color = k.Split(';')[2],
                    IsNew = k.Split(';')[3],
                    Warranty = k.Split(';')[4],
                    Price = k.Split(';')[5]
                });
            var report = data.GroupBy(k => k.Type).Select(p =>
                new
                {
                    Type = p.Key,
                    TypesCount = p.Count(),
                    ColorVarityCount = p.Select(o => o.Color).Distinct().Count()
                });
