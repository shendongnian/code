    [HttpPost]
    [ResponseType(typeof(Credit))]
    public async Task<IHttpActionResult> Post([FromBody] PaymentModel payment)
            {
                try
                {
                    if (payment == null || payment.Crediter == null) return BadRequest();
                    var response = new Credit
                    {
                        BankInformationId = payment.Crediter.BankInformationId
                    };
    
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
