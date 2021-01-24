     [HttpPost]
     public async Task<IHttpActionResult> Get([FromBody] CoreBarCodeDTOcoreBarCode coreBarCode)
     {
        string Bar_Code = coreBarCode.json;
        //work with the JSON here, with Newtonsoft for example
        var obj = JObject.Parse(Bar_Code);
        // obj["MouseSampleBarcode"] now = "MOS81"
    
     }
