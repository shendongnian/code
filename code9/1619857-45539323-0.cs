            [HttpDelete("{tagAsDeletedOnly?}")]       
            public async Task<IHttpActionResult> Remove([FromBody] Department tObj, [FromRoute]bool? tagAsDeleteOnly) // use FromRoute
            {
                _bll.Delete(tObj, tagAsDeleteOnly ?? true);
    
                var result = await _bll.Save();
    
                return Ok(new WebResult
                {
                    Data = tObj,
                    Total = (int)result,
                    Result = result > 0
                });
            }
