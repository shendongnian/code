    Song[] songs = new Song[Titles.Length];
    Parallel.For(0, Titles.Length,
                   index => 
                    {
                        songs[index] = new Song
                        {
                            Title = Titles.ElementAt(index),
                            Artist = Artists.ElementAt(index),
                            Image = Images.ElementAt(index)
                        }
                    });
    return songs.ToList();
