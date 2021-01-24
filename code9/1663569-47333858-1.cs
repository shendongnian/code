    [HttpGet("/")]
    public async Task<IHttpActionResult> Get(string mouseSampleBarcode)
    { 
       var rootObject = new CoreBarCodeDTO.RootObject
       {
            MouseSampleBarcode = mouseSampleBarcode
       }
       ...
    }
