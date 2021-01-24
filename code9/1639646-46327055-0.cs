    [Authorize]
    public IActionResult GetMyFile()
    {
        byte[] fileBytes = System.IO.File.ReadAllBytes("MyPrivateFiles/file1.txt");
        return new FileContentResult(fileBytes, "text/plain");
    }
