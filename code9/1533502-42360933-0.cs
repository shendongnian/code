    public async Task<HttpResponseMessage> GetAsync()
    {
    	try
    	{
    		using (var entities = new DbEntities())
    		{
    			var resourceModelList = entities.Resources.Select(r=> new ResourceModel{Build Your Resource Model}).ToList();
    		  
    			if (resourceModelList.Count == 0)
    			{
    				return this.Request.CreateResponse<string>(HttpStatusCode.NotFound, "No resources found.");
    			}
    			
    			return this.Request.CreateResponse<List<ResourceModel>>(HttpStatusCode.OK, resourceModelList, "application/json");
    		}
    	}
    	catch (Exception ex)
    	{
    		return this.Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Something went wrong.");
    	}
    }
