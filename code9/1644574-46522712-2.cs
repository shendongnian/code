     [HttpPut]
     [Consumes("multipart/form-data")]
     public void Put(IFormFile file)
     {
        var stream = file.OpenReadStream();
     }
