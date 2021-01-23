    var result = db.Notes.GroupBy(n => n.PersonId)
                         .Select(g => new NoteGrp
                          {
                              PersonID = g.Key,
                              Notes = g.Select(x => x.NoteText)
                          });
    public class NoteGrp
    {
        public int PersonID { get; set; }
        public IEnumerable<string> Notes { get; set; }
        ...
        public string Note
        { get { return string.Join(", ", Notes); } }
    }
