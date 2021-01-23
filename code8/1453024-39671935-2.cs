    public IEnumerable<TrackBase> TrackGetByGenre(int genreId)
    {
        var result = ds.Genres.Where(p => p.GenreId == genreId);
        return mapper.Map<IEnumerable<TrackBase>>(result);
    }
