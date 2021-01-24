    [HttpGet("stream")]
    public async Task<FileStreamResult> Stream()
    {
        try
        {
             var stream = new MemoryStream(System.IO.File.ReadAllBytes("physical path of file"));
             var response = File(stream, "Mime Type of file");
             return response;
        }
        catch (Exception ex)
        {
             Console.WriteLine(ex);
             throw;
        }
    }
