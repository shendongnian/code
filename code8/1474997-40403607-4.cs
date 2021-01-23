    public IEnumerable<NoteGrp> GetNotes()
    {
        using (MyContext db = new MyContext())
        {
            var result = (from n in db.Notes
                          group n.NoteText by n.PersonID into g
                          select new { //Creating anonymous object with only the needed information
                              PersonID = g.Key, 
                              Notes = g.ToList()
                          }).AsEnumerable() //Bringing items to memory so can use string.Join
                         .Select(item => new NoteGroupDTO { //Instantiating new DTO object
                             PersonID = item.PersonID,
                             Notes = string.Join(", ", item.Notes)
                         }).ToList();
            return result;
        }
    }
