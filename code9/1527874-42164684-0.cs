    .Select(i => new AlbumResponse
                {
                    AlbumId = i.AlbumId,
                    artist = new ArtistResponse {  Name= i?.artist?.Name ?? String.Empty, ArtistId=i?.artist?.ArtistId ?? 0},
                    genre = i.genre,
                    Title = i.Title
                }).ToList();
