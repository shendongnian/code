    [Route("/files/{file_id}.{ext?}")]
    public async Task<IActionResult> GetFile(string file_id, string ext)
    {
      return File(await Globals.GetFile(file_id), BakaMime.GetMimeType(ext));
    }
