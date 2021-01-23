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
            var viewModel = new HomeViewModel();
            viewModel.Artists = _songRepository.AllArtists().ToList();
            viewModel.Genres = _songRepository.AllGenres().ToList();
            viewModel.SelectedArtists = viewModel.Artists
                .Where(a => spec.ArtistsToInclude.Contains(a))
                .ToList();
            viewModel.SelectedGenres = viewModel.Genres
                .Where(g => selectedGenres.Contains(g.Id))
                .ToList();
            viewModel.Songs = songs.ToList();
            if (save != null)
            {
                var smartPlaylist = new SmartPlaylist();
                smartPlaylist.Name = playlistName;
                smartPlaylist.Specification = spec;
                var playlistRepo = new SmartPlaylistRepository(_dbContext);
                playlistRepo.Add(smartPlaylist);
                return RedirectToAction("Index", "SmartPlaylists");
            }
            return View(viewModel);
        }
