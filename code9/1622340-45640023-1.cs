    [HttpGet("content")]
    public async Task<FileContentResult> Content()
    {
        try
        {
            HttpContext.Response.ContentType = "Mime Type of file";
            var result = new FileContentResult(System.IO.File.ReadAllBytes("physical path of file"), file.SelectedMime)
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
