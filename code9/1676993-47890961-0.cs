    [HttpPost]
    public IHttpActionResult GetPlaylistXml(int playlistId, [FromBody] JObject data)
    {
        ....
        var serializer = new XmlSerializer(typeof(playList));
        using (var memStream = new MemoryStream())
        {
            serializer.Serialize(memStream, playList);
            var returnModel = new 
            {
               Title = playList.Title,
               // either a byte array (which is converted to Base64, or the XML string)
               Playlist = memStream.ToArray() 
            };
            return Json(returnModel);
        }
    }
