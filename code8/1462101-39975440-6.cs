    var values = DBContext.Events.Where(o => o.EventName.Contains(searchParam))
                                 .Select(x => x.EventID);
    var GroupedList = DBContext.Journals.Where(j => values.Contain(j.eventID))
                                        .Select(t => new JournalGrouped()
                                        {
                                            JournalID = t.JournalID,
                                            JournalDate = t.JournalDate
                                        }).Distinct();
