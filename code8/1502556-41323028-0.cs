    public class LectureFormViewModel
    {
            public int Id { get; set; }
            public string Term {get;set;}
            public byte Genre { get; set; }
            public IEnumerable<Genre> Genres { get; set; }
    }
