    static void displayMovie(List<Movie> mList)
    { 
        Movie m;
        Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-20} {4,-20} {5,-10}","No","Title","Duration","Genre","Classification","Opening Date");
        var gList = new List<List<string>>();
        for(int i = 0; i<mList.Count;i++)
        {
            m = mList[i];
                string genres = string.Join(", ", m.GetGenreList().ToArray());
                Console.WriteLine("{0,-10} {1,-30} {2,-10} {3,-20} {4,-20} {5,-10}", i + 1, m.Title, m.Duration, genres, m.Classification, m.openingDate);
            }
        }
    }
