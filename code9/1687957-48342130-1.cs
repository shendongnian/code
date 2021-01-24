        var myJournals = from s in db.Journals
                         where !s.Blacklist
                         join recToJournals in db.RecipientsToJournals 
                           on s.JournalID equals recToJournals.JournalID
                         join recipients in db.Recipients 
                           on recToJournals.RecipientID equals recipients.RecipientID
                          
                         join reaToJournals in db.ReadersToJournals 
                           on s.JournalID equals reaToJournals.JournalID
                         join readers in db.Readers 
                           on reaToJournals.ReaderID equals readers.ReaderID
                         select new 
                                {
                                    JournalID = s.JournalID,
                                    Title = s.Title,
                                    RecipientFullName = recipients.FullName,
                                    ReaderFullName = readers.FullName
                                };
        var result = myJournals.GroupBy(j => new { j.JournalID, j.Title, j.RecipientFullName })
                               .Select(g => new AnalysisViewModel
                                            {
                                                JournalID = g.Key.JournalID,
                                                Title = g.Key.Title,
                                                RecipientsFullNames = g.Key.RecipientFullName,
                                                ReadersFullNames = g.Select(r => r.ReaderFullName).ToList(),                                                
                                            }
                                      )
                               .ToList();
