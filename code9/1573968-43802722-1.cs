    return database.Table<MusicItems>() 
                        .Join(database.Table<MusicInThemes>().Where(t => t.ThemeId == ThemeID)
                            ,m =>m.ResId
                            ,t => t.ResId
                            ,(m,t) => new {mym = m, myt = t })
                        .Select(a => new Playlist
                            {
                                Name = a.mym.Name,
                                ResId = a.mym.ResId,
                                LoopStart = 0
                            })  
                        .ToList();
