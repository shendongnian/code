    [HttpPost("/")]
    public async Task<IHttpActionResult> Post([FromBody] CoreBarCodeDTO.RootObject coreBarCode)
    { 
       string Bar_Code = coreBarCode.MouseSampleBarcode.ToString();
       ...
    }
