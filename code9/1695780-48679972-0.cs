    [HttpGet]
    EnableQuery]
            public IHttpActionResult IsTested([FromOdataUrl]int? number1,[FromOdataUrl] int? number2,[FromOdataUrl] int? number3, string value)
            {
                
                    ObjectParameter isTested = new ObjectParameter("isTested", typeof(bool));
                    var result = db.vm_getTested(number1, number2, number3, value, isTested)
                        .ToList();
                    bool asd = Convert.ToBoolean(isTested.Value);
                    
                    return Ok(asd);
                }
