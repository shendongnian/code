    [HttpGet]
    [Route("playlist/{id}")]
    public IHttpActionResult GetPlaylistMetaData(int id)
    {
        return Json(new {
            Id = 1,
            Title = "My Playlist",
            TrackCount = 24,
            ...
        });
    }
    [HttpGet]
    [Route("playlist/{id}/file")]
    public IHttpActionResult GetPlaylistFile(int id)
    {
        ....
        var serializer = new XmlSerializer(typeof(playList));
        using (var memStream = new MemoryStream())
        {
            serializer.Serialize(memStream, playList);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(memStream.ToArray(), 0, (int)memStream.Length)
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = playlist.Title + ".xml"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = ResponseMessage(result);
            return response;
        }
    }
