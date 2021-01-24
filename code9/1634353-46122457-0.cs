    public class MyItem
    {
        public int Id { get; set; }
        public string Source { get; set; }
    }
    var data = _context.UploadedFiles
        .Select(p => new MyItem
        {
            Id = p.Id,
            Source = p.Source
        })
        .ToListAsync();
