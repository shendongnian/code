    public IEnumerable<TrackBase> TrackGetAllPop()
    {
        var AllPop = ds.Tracks.Where(p => p.GenreId == 9);
        return mapper.Map<IEnumerable<TrackBase>>(AllPop);
    }
