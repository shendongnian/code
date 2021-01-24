    for(int i = 0; i<MovieList.Count; i++)
        {
            Console.WriteLine(
                   string.Format(
                       "yourformatstring", 
                       i + 1, 
                       MovieList[i].Title, 
                       MovieList[i].Duration, 
                       genreList[i],     //  <----THE PROBLEM IS HERE
                       MovieList[i].Classification,         
                       MovieList[i].OpeningDate));
        }
