    var result = (from n in db.Notes
                  join p in db.Persons on n.PersonID equals p.PersonID
                  group n.NoteText by new { n.PersonID, n.PersonName, p.DOB, p.Status } into g
                  select new { 
                      PersonID = g.Key.PersonID, 
                      PersonName = g.Key.PersonName, 
                      DOB = g.Key.DOB, 
                      Status = g.Key.Status, 
                      Notes = g.ToList()
                  }).AsEnumerable() 
                 .Select(item => new PersonNoteDTO { 
                     PersonID = item.PersonID,
                     Notes = string.Join(", ", item.Notes)
                 }).ToList();
