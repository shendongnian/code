    [Route("api/Music/Album/{uniqueCDcode}")]
    public HttpResponseMessage GetAlbum(int uniqueCDcode)
    {
        db.CDClicked.Add(uniqueCDcode);
    
        return Request.CreateResponse(HttpStatusCode.OK, 
            new { AlbumMusic = db.Music
                .Where(am => am.uniqueCDcode == uniqueCDcode }));
    }
