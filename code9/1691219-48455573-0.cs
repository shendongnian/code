    .GroupBy(c => new { c.PropertyKey, c.Color }, 
             c => c.Value,
            (key, v) => new MyObject { 
                            PropertyKey = key.PropertyKey, 
                            Color = key.Color, 
                            Values = v.ToList() });
