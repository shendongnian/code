    [HttpPut("api/import")]
    public IActionResult ImportZip()
    {
        var file = Request.Form.Files.FirstOrDefault();
        if (file == null)
            return BadRequest();
        try
        {
            using (var zip = new ZipArchive(file.OpenReadStream()))
            {
                // do stuff with the zip file
            }
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }
