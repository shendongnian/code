    [HttpGet("content")]
    public async Task<FileContentResult> Content()
    {
        try
        {
            var result = new FileContentResult(System.IO.File.ReadAllBytes("physical path of file"), "Mime Type of file")
            {
                FileDownloadName = "Your FileName"
            };
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
