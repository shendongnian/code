    [HttpPost]
    [ActionName("AddAudio")]
    public async Task<IHttpActionResult> AddAudio([FromUri]string name)
    {
      try
      {
        string file = Path.Combine(@"C:\Users\username\Desktop\UploadedFiles", fileName);
        using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write,
            FileShare.None, 4096, useAsync: true))
        {
          await Request.Context.CopyToAsync(fs);
        }
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("ERROR: Audio could not be saved on server.");
      }
    }
