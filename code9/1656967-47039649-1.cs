            var rawData = System.IO.File.ReadAllText("aa.txt");
            var data = rawData.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Select(k =>
                { var segments = k.Split(';');
               return new
                {
                    Type = segments[0],
                    Size = segments[1],
                    Color = segments[2],
                    IsNew = segments[3],
                    Warranty = segments[4],
                    Price = segments[5]
                };});
            var report = data.GroupBy(k => k.Type).Select(p =>
                new
                {
                    Type = p.Key,
                    TypesCount = p.Count(),
                    ColorVarityCount = p.Select(o => o.Color).Distinct().Count()
                });
