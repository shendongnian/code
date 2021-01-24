    var note = new NoteDto
    {
        Date = "1/1/2018",
        Time = "4:00 PM",
        Author = "Some Guy",
        NoteText = "My Note",
        Project = "A Project"
    };
    var xml = note.ToXml();
