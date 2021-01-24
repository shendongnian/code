    [CustomExceptionsFilter]
    [CustomValidateModelFilter]
    [Authorize(Roles="whatever")]
    public IActionResult ActionMethod(params){
      return Ok(this._myService.whatever());
    }
