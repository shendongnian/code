    [HttpPost]
    public IHttpActionResult Post([FromBody] CardStatusRoot cardStatus) {
        try {
            HttpRequestMessage request = this.Request;
            if (cardStatus == null) {
                return BadRequest("Card data not provided");
            }
            if (cardStatus.Data.TransactionType.ToLower() == "card") {
                //... Process;
            }
        } catch (Exception ex) {
            try {
                // Log the failure to fund the card
            }
            catch { }
            return InternalServerError();
        }
        return Ok();
    }
