    public static List<string> GetComments(RootObject root, string keyword)
    {
        return root.albums.data
            .SelectMany(a => a.photos.data, (a,p) => new { Album = a.name, Comments = p.comments })
            .Where(p => p.Comments != null)
            .SelectMany(p => p.Comments.data, (p,c) => new { Album = p.Album, From = c.from, Message = c.message })
            .Where(c => c.Message.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            .Select(c => c.From.name + " - " + c.Album + " - " + c.Message)
            .ToList();
    }
