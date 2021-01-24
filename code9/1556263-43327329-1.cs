            var repository = new Repository();
            var listOfMovies = repository.GetAllMovies();
            var movies = new Library(listOfMovies);
		
			var selectedMovies1 = movies.GetByYear(2000).GetById(1).GetByGenre("Action");
            var selectedMovies2 = movies.GetByYear(2000).GetById(2);
  
           foreach (var movie in selectedMovies1)
            {
                Console.WriteLine("Selected 1 - Title: {0} , Year {1}, Group: {2}, Genre: {3}", movie.Title,movie.Year,movie.GroupId, movie.Genre);
            
           }
          selectedMovies2.Display();
