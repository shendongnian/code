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
                .Select(a =>
                        new Overlay.ReportColourScheme
                            {
                                ID = a.SchemeID,
                                Label = a.Label,
                                Colours = new List<Overlay.ReportColour>
                                    {
                                        new Overlay.ReportColour
                                            {
                                                ID = a.ColourID,
                                                Value = a.Colour,
                                                Result = a.Result
                                            }
                                    }
                            })
                .ToArray();
