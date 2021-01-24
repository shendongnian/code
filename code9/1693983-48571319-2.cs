    var ans2 = TableA.Where(a => a.ResourceID == 1)
                     .SelectMany(a => TableB.Where(b => b.DisplaySettingID == 1).Where(b => b.ElementNameID == a.TabNotesCodeID || b.ElementNameID == a.TabLabelCodeID)
                                            .DefaultIfEmpty(),
                                            (a, b) => new {
                                                SubSectionName = (b.CustomValue ?? a.TabLabelCodeID),
                                                SubSectionNote = (b.CustomValue ?? a.TabNotesCodeID)
                                            }
                                );
