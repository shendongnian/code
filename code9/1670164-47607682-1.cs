    var query = entities.Movie.Join(entities.Movie_Instance,
                                s => s.ID_Movie,
                                c => c.FK_ID_Movie,
                                (s, c) => new {s, c}).Where(sc => sc.c.FK_ID_Movie == movie.ID_Movie).Select(sc => sc.s)
                            .Count();
