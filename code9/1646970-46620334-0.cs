    var returnjson = dbband.Bands.AsEnumerable().Select(x => new Dictionary<string, object>
    {
        { "NewBandName", x.BandName.ToString() },
        { 
            x.BandName.ToString(), 
            dbband.BandSongs
                .AsEnumerable()
                .Where(y => y.BandId == x.Id)
                .Select(z => new NSongs() {
                    NSongTitle = z.SongTitle
                })
                .ToList()
        }
    });
