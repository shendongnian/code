    Exhibits
       .Where(t => t.PLAY_TS >= new DateTime(2016, 8, 10) && t.PLAY_TS < new DateTime(2016, 8, 11))
       .Select(t => new { t.CLIENT_ID, t.SONG_ID })
       .Distinct()
       .GroupBy(c => c.CLIENT_ID)
       .Select(c => c.Count())
       .GroupBy(g => g)
       .Select(g => new { DISTINCT_PLAY_COUNT = g.Key, CLIENT_COUNT = g.Count() })
       .ToList();
