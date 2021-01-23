    [HttpPost("UploadFiles")]
    public async Task<IActionResult> Post(List<IFormFile> files)
    {
        Sp4RestClient dataPovider = new Sp4RestClient("http://localhost:60077/");
        long size = files.Sum(f => f.Length);
            
        foreach (var file in files)
        {
           await dataPovider.ImportFile(file);
        }
        return Ok();
    }
