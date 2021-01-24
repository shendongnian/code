    [HttpGet]
    public async Task<IActionResult> PhysicalPath()
    {
        var result = new PhysicalFileResult("physical path of file", "Mime Type of file")
        {
            FileDownloadName = "Your FileName",
            FileName = "physical path of file"
        };
        return result;
    }
