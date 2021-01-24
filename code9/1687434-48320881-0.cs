    [HttpGet]
    [Route("Download/{documentId}")]
    public async Task<IActionResult> DownloadDocument(string documentId)
    {
        try
        {
            var result = await TheDocumentService.DownloadDocument(documentId);
            return File(result.Content.ReadAsByteArrayAsync().Result, result.Content.Headers.ContentType.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
