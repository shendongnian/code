    var genresTracks = tracks.SelectMany(track => track.Genres, (track, genre) => new 
                             { 
                                 // you might want to correct the Name property
                                 // with the correct one.
                                 Track = track.Name, 
                                 Genre = genre
                             })
                             .GroupBy(tg => tg.Genre)
                             .Select(gr => new 
                             {
                                 Genre = gr.Key, 
                                 Tracks = gr.Select(x=>x.Track)
                             });
    foreach(var genreTracks in genresTracks)
    {
        var tracksCsv = string.Join(",", genreTracks.Tracks);
        Console.WriteLine($"{genreTracks.Genre} - {tracksCsv}");
    }
