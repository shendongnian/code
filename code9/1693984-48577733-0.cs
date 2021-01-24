                        _uow.Repository<TableA>().Get().AsNoTracking()
                        .GroupJoin(
                            _uow.Repository<TableB>().Get().AsNoTracking().Where(b => b.DisplaySettingId == 1),
                            a => new { note = a.TabNotesCodeId, label = a.TabLabelCodeId },
                            b => new { note = b.ElementNameId, label = b.ElementNameId },
                            (a, b) => new { a,b })
                        .Where(joinTables => joinTables.a.ResourceId == 1)
                        .SelectMany(
                            joinTables => joinTables.b.DefaultIfEmpty(),
                            (joinTables, b) => new SubSection()
                            {
                                LayoutTab = joinTables.a.LayoutTab,
                                SubSectionName = b.CustomValue ?? joinTables.a.TabLabelCodeId,
                                SubSectionNote = b.CustomValue ?? joinTables.a.TabNotesCodeId
                            });
