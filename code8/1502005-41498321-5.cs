    public ActionResult Index(List<int> selectedGenres = null, 
            List<string> selectedArtists = null, 
            string titleSearch = null,
            int minRating = 0,
            string filter = null,
            string save = null,
            string playlistName = null)
        {
            if (selectedArtists == null) { selectedArtists = new List<string>(); }
            if (selectedGenres == null) { selectedGenres = new List<int>(); }
            var spec = new GlobalSongSpecification();
            spec.ArtistsToInclude.AddRange(selectedArtists);
            spec.GenreIdsToInclude.AddRange(selectedGenres);
            spec.MinRating = minRating;
            spec.TitleFilter = titleSearch;
            var songs = _songRepository.List(spec);
            //You can work with the filtered data at this point
        }
