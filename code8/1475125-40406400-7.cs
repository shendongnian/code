    var result = (from n in db.Notes
                  join p in db.Persons on n.PersonID equals p.PersonID
                  group new { n.NoteText, n.LineNo } by new { n.PersonID, n.PersonName, p.DOB, p.Status } into g
                  select new { 
                      PersonID = g.Key.PersonID, 
                      PersonName = g.Key.PersonName, 
                      DOB = g.Key.DOB, 
                      Status = g.Key.Status, 
                      Notes = g.OrderBy(i => i.LineNo).Select(i=> i.NoteText)
                  }).AsEnumerable()
                 .Select(item => new PersonNoteDTO { 
                     PersonID = item.PersonID,
                     PersonName = item.PersonName,
                     DOB = item.DOB,
                     Status = item.Status,
                     Notes = string.Join(", ", item.Notes)
                 }).ToList();
