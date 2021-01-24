        using(var Context = GetContext())
        {
            var lastDate = DateTime.Now.Date.AddDays(-30);
            var result = Context.SongPlayDailies.Where(x => DateTime.Compare(x.PlayDate, lastDate) >= 0)
              .GroupBy(x => x.SongID)
              .Select(x => new { SongID = x.Key, NumberOfPlays = x.Sum(y => y.NumberOfPlays) })
              .OrderByDescending(x => x.NumberOfPlays)
              .Take(count)
              .Select(x => Context.Songs.Include("Album").Include("Album.AccountInfo").FirstOrDefault(y=>y.SongId==x.SongId))
              .Where(z=> z!=null).ToList();
            return result;
        }
    }
