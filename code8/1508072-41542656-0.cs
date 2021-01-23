     var currentUserMovies=UserMovieRanks.Where(u=>u.userId==userId).Select(m=>m.movieId).ToList();
    
    	var userMovieMatch = TwitterUsers.Where(u => u.userID != userId).Select(tu=>
    	{
    		var userMovies=UserMovieRanks.Where(u=>u.userId==tu.userID).Select(m=>m.movieId).ToList();
    		return new   {
    			MovieIds=userMovies,
    			Count=userMovies.Count(c=>currentUserMovies.Contains(c)),
    			NotWatchedByUser=userMovies.Except(currentUserMovies)
    		};
    	});
    
    	var bestPick=userMovieMatch.OrderByDescending(o=>o.Count).First();
