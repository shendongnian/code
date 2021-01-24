    [HttpPost]
    [ActionName("transfer")]
    public IHttpActionResult FundTransfer([FromBody] FundTransfer transfer) {
        var response = Message(transfer);
        if (response.MessageCode == "11") {
            return Content(HttpStatusCode.BadRequest, response);
        } else {
            return Ok(response);
        }
    }
