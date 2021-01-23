    using (var mc = new MangaContext())
    {
        var query = mc.Mangas
            .Select(m => new MangaDTO
            {
                id = m.Id,
                name = m.Name,
                genres = m.Genres.Select(o => o.Name).ToList(),
                author = m.Author,
                artist = m.Artist,
                score = m.Score,
                year = m.Year,
                aliases = m.Aliases.Select(o => o.Name).ToList(),
            });
        var mangas = query.ToList();
        return mangas;
    }
