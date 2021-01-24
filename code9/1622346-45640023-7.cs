    [HttpGet("content")]
    public async Task<FileContentResult> Content()
    {
        var result = new FileContentResult(System.IO.File.ReadAllBytes("physical path of file"), "Mime Type of file")
        {
            FileDownloadName = "Your FileName"
        };
        return result;
    }
