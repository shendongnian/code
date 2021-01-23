    return DbContext.Schemes
        .Select(s => new Overlay.ReportColourScheme
        {
            ID = s.SchemeID,
            Label = s.Label,
            Colours = s.Colours
                .Select(sc => new Overlay.ReportColour
                {
                    ID = sc.ColourID,
                    Value = sc.Colour,
                    Result = sc.Result,
                })
               .ToList()
        })
        .ToArray();
