    [HttpGet("{id}")]
    public IActionResult Get(string id) {        
        var r = unitOfWork.Resources.Get(id);
        unitOfWork.Complete();
        Models.Resource result = ConvertResourceFromCoreToApi(r);
        if (result == null) {
            return NotFound();
        } else {
            return Ok(result);
        }        
    }
