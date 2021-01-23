    JournalList  = new List<Journal>();
     foreach (string eventId in values)
      {
        var results = DBContext.Journals.Where(j => j.eventID.Equals(eventId)).ToList();
     RegJournalList.AddRange(results);
      }
     GroupedList = JournalList.Select(t => new JournalGrouped()
                        {
                            JournalID = t.JournalID,
                            JournalDate = t.JournalDate
                       }).Distinct().ToList();
