    var foos = db1.Foos.Where(d => d.IsActive)
                       .Select(c => new 
                       {
                           c.prop1,
                           c.prop2,
                           c.prop3,
                       })
                       .ToList();
	var bars = db2.Bars.ToList();
	var fooBars = bars.Join(foos,
                            x => new { x.prop1, x.prop2, x.prop3 },
                            y => y,
                            (x, y) => x)
                      .ToList();
