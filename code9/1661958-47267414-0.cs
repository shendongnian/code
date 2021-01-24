    public IHttpActionResult GetFieldInfo() {
        //...
    
        var model = new { 
            //assuming: byte[] GetBinaryFile(...)
            data = Convert.ToBase64String(GetBinaryFile(localFilePath)), 
            result = "final",
            //...other properties...
        };
    
        return Ok(model);
    }
