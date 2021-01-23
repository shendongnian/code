    return DbContext.Schemes
        .GroupJoin(DbContext.SchemeColours,
            s => s.SchemeID,
            sc => sc.SchemeID,
            (s, colours) => new Overlay.ReportColourScheme
            {
                ID = s.SchemeID,
                Label = s.Label,
                Colours = colours
                    .Select(sc => new Overlay.ReportColour
                    {
                        ID = sc.ColourID,
                        Value = sc.Colour,
                        Result = sc.Result,
                    })
                    .ToList()
            })
        .ToArray();
