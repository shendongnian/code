    for(int i = 0; i<MovieList.Count; i++)
    {
          String genre = String.Join(",", MovieList[i].GetGenreList());
          Console.WriteLine(string.Format("{0,-5}{1,-30}{2,-10}{3,-20}{4,-15}{5,-15}", i + 1, MovieList[i].Title, MovieList[i].Duration, genre, MovieList[i].Classification, MovieList[i].OpeningDate));
          Console.WriteLine();
          Console.Write("");
          Console.ReadLine();
    }
