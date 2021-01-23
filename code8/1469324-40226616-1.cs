    public async Task<IActionResult> Index(int MovieID)
    {
        var vm = new MovieGenreViewModel();
        
        IQueryable<string> YearQuery = from m in _context.Years
                                        orderby m.MovieYear
                                        select m.MovieYear;
    
        //Following query selects only a single movie based on Primary Key ID
        var movie =  _context.Movies.FirstOrDefault(x=>x.ID==movieID);
                    
        if(movie==null)
           return Content("Movie not found"); // to do : Return a view with message
         
        vm .MovieReleaseYears = new SelectList(await YearQuery.ToListAsync());
        vm .MovieId= movie.ID;
        vm .MovieName= movie.Name;
    
        return View(vm );
    }
