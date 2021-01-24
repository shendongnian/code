    [HttpPost("/")]
    public async Task<IHttpActionResult> Get([FromBody] CoreBarCodeDTO.RootObject coreBarCode)
    { 
       string Bar_Code = coreBarCode.MouseSampleBarcode.ToString();
       ...
    }
