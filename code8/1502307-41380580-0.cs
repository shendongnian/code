    [AllowAnonymous]
            [HttpPost]
            [Route("api/PayPal/IPN")]
            [ResponseType(typeof(OrderPayPalDTO))]
            public async Task<IHttpActionResult> PayPalIPN()
            {
                try
                {
                    decimal tot;
    
                    var data = this.Request.Content.ReadAsStringAsync().Result;
                    if (data == null) return BadRequest();
    
                    // Parse the query string variables into a NameValueCollection.
                    NameValueCollection qscoll = HttpUtility.ParseQueryString(data);
                    PayPalViewModel payPalModel = new PayPalViewModel();
    
                    var payPal = payPalModel.ToPayPalVM(qscoll); //HRE IS A EXTENSION METHOD TO MAP to a CLASS
    
                    if (payPal == null) return InternalServerError(new Exception());
    
                    //Try cast total from paypal
                    if (!decimal.TryParse(payPal.mc_gross, out tot)) return InternalServerError(new Exception(Constant.Error.PAYMENT_ERROR_TOTAL_CAST));
    
                   
    
                 
                    // If status is Ok /or Completed
                    if (payPal.payment_status.Equals(Constant.PaymentStatus.PAYED) || payPal.payment_status.Equals(Constant.PaymentStatus.COMPLETED))
                    {
                        // update payment
                        bool ok = await this.UpdatePayment(order, user);
                        if (!ok) return InternalServerError(new Exception(Constant.Error.PAYMENT_ERROR_UPDATE));
                    }
    
                    return Ok(order);
                }
                catch (Exception ex)
                {
                    _logger.LogException(ex);
                    return (Constant.CONFIGURATION_GLOBALS.IS_DEVELOPMENT_MODE)
                      ? InternalServerError(ex)
                      : InternalServerError(new Exception(Constant.Error.ERROR_GENERIC_500));
                }
            }
		
