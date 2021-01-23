    var result = db.Notes.GroupBy(n => n.PersonId)
                         .AsEnumerable()
                         .Select(g => new NoteGrp
                         {
                             PersonID = g.Key,
                             Notes = string.Join(", ", g.Select(x => x.NoteText))
                         });
