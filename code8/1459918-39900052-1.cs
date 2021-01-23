    return
        DbContext.Schemes
                .Join(
                    DbContext.SchemeColours,
                    s => s.SchemeID,
                    sc => sc.SchemeID,
                    (s, sc) => new
                        {
                            s.SchemeID,
                            s.Label,
                            sc.Colour,
                            sc.Result,
                            sc.ColourID
                        })
                // After joining you group by SchemeID, in this way you have 
                // for each SchemeID the group of related items
                .GroupBy(a => a.SchemeID)
                // You then create your result, starting from the main object
                .Select(g =>
                        new Overlay.ReportColourScheme
                            {
                                ID = g.Key,
                                // I suppose you have at least a child for each SchemeID, 
                                // otherwise you can check if the list is empty
                                Label = g.FirstOrDefault().Label,
                                // For each group you create a list of child object
                                Colours = g.Select(v => new Overlay.ReportColour
                                            {
                                                ID = v.ColourID,
                                                Value = v.Colour,
                                                Result = v.Result
                                            }).ToList()
                            })
                .ToArray();
