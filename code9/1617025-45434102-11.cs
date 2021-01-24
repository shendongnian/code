            [HttpPost]
            [Route("orders")]
            public async Task<IHttpActionResult> Post([FromBody]List<Models.Model.Order> orders)
            {
    
                if (orders == null)
                    return BadRequest("Unusable resources.");
    
                if (validatedOrders.Count <= 0)
                    return BadRequest("Unusable resources.");
    
                try
                {
                    //Create abstracted Identity model to pass around layers
                    var identity = User.Identity as ClaimsIdentity;
    
                    var identityModel = IdentityModel.Create(identity);
                    if (identityModel == null)
                        return StatusCode(HttpStatusCode.Forbidden);
    
                    var response =  await _orderService.AddAsync(validatedOrders, identityModel);
                    return Ok(response);
                }
                catch (System.Exception ex)
                {
                    return InternalServerError();
                }
                finally
                {
                    _orderService.Dispose();
                }
            }
