    public IEnumerable<NoteGrp> GetNotes()
    {
        using (MyContext db = new MyContext())
        {
            var result = (from n in db.Notes
                          group n.NoteText by n.PersonID into g
                          select new NoteGroupDTO { 
                              PersonID = g.Key, 
                              Notes = string.Join(", ",g) 
                          }).ToList();
            return result;
        }
    }
