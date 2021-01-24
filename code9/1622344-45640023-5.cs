    [HttpGet("physicalPath")]
    public async Task<IActionResult> PhysicalPath()
    {
        try
        {
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
