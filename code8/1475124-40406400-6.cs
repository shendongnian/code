    var result = (from p in db.Persons
                  join n in db.Notes on p.PersonID equals n.PersonID into personNotes
                  select new
                  {
                      Person = p
                      Notes = personNotes.OrderBy(pn => pn.LineNo).Select(pn => pn.NoteText)
                  }).AsEnumerable()
                 .Select(item => new PersonNoteDTO { 
                     PersonID = item.Person.PersonID,
                     PersonName = item.Person.PersonName,
                     DOB = item.Person.DOB,
                     Status = item.Person.Status,
                     Notes = string.Join(", ", item.Notes)
                 }).ToList();
