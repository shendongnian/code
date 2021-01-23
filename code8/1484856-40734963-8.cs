        [Route("api/myApiMethod")]
        public Response<DomainModel> GetDetails(string ROOM, DateTime DOB_GT)
        {
        	try
        	{
        		DomainModel	myDomainModel	= new DomainModel(ROOM, DOB_GT);
        		return new Response<DomainModel>(myDomainModel);
        	}
        	catch (Exception ex)
        	{
        		return new Response<DomainModel>(ex);
        	}
        }
