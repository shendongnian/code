            [HttpDelete]
            [Route("{id:int:min(1)}")]
            public async Task<HttpResponseMessage> DeleteAsync(int id)
            {
                if(id < 0 )
                {
                    return await Task.FromResult<HttpResponseMessage>(Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Id should be greater than zero."));
                }
                try
                {
                    var itemToDelete = (from i in Values
    									where i.Id == id
    									select i).SingleOrDefault();
    									
                    if (itemToDelete == null)
                    {
                        return await Task.FromResult<HttpResponseMessage>(Request.CreateResponse<string>(HttpStatusCode.NotFound,
                                            string.Format("Unable to find a value for the Id {0}", id))); 
                    }
    
                    Values.Remove(itemToDelete);
                    return await Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK));
                }
                catch (Exception ex)
                {
                     return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Something went wrong."); // Default message if exception occured
                }
            }
		
		
