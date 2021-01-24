    [HttpGet("physicalPath")]
    public async Task<IActionResult> PhysicalPath()
    {
        try
        {
            HttpContext.Response.ContentType = "Mime Type of file";
            var result = new PhysicalFileResult("physical path of file", "Mime Type of file")
            {
                FileDownloadName = "Your FileName",
                FileName = "physical path of file"
            };
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
