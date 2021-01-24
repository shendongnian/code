    [HttpGet("stream")]
    public async Task<FileStreamResult> Stream()
    {
        var stream = new MemoryStream(System.IO.File.ReadAllBytes("physical path of file"));
        var response = File(stream, "Mime Type of file");
        return response;
    }
