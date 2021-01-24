        cu.Substation,
        cu.ColumnTitle,
    } into gs
    select new
    {
        Substation = gs.Key.Substation,
        ColumnTitle = gs.Key.ColumnTitle,
        ValueAmount = gs.Max()
    };
	
	var final = 	
	(from c in DtFinals
	join d in dt on new {c.Substation, c.ColumnTitle,c.ValueAmount} equals new {d.Substation, d.ColumnTitle, d.ValueAmount}
	select new 
	{ ptime = c.Ptime, 
	Substation = d.Substation, 
	ColumnTitle = d.ColumnTitle,
	ValueAmount = d.ValueAmount
	});
