    [Route("{userName}/{searchCriteria}")]
    [HttpGet]
    public IHttpActionResult Events(string accountNumber, string searchCriteria) {
        bool isInputValid = _inputValidation.IsTrackingEventInputValid(accountNumber, searchCriteria);
        if (isInputValid) {
            return Ok("my data");
        } else {
            return BadRequest(ExceptionHandlingMessages.InvalidArgumentException);
        }
    }
