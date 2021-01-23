     return this.Context.tRealty.AsNoTracking().Where(
                    x => x.Id == id && x.RealtyProcess == RealtyProcess.Visible).Select(
                    s => new
                    { .....
    // subquery
    videos = s.TVideo.Where(video => video.RealtyId == id && video.IsPublicOnYouTube).
                            Select(video => video.YouTubeId).ToList()), // missing ToList()
    .....
     }).FirstOrDefault();
